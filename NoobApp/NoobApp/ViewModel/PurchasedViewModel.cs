﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Entity;
using NoobApp.Enum;
using NoobApp.Event;
using NoobApp.Model;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;

namespace NoobApp.ViewModel {
  public class PurchasedViewModel : ViewModelBase {

    #region - Instance Variables -

    private readonly Entity.Event _event;

    #endregion

    #region - Constructor -

    public PurchasedViewModel(User user, Entity.Event eventEntity) {
      User = user;
      _event = eventEntity;

      InitializeData();
    }

    #endregion

    #region - Properties -

    #region -- User --

    public static string UserPropertyName = "User";
    private User _user;
    public User User {
      get {
        return _user;
      }
      set {
        if (_user == value) {
          return;
        }

        _user = value;
        RaisePropertyChanged(UserPropertyName);
      }
    }

    #endregion

    #region -- AttendancePrice --

    public static string AttendancePricePropertyName = "AttendancePrice";
    private float _attendancePrice;
    public float AttendancePrice {
      get {
        return _attendancePrice;
      }
      set {
        if (_attendancePrice == value) {
          return;
        }

        _attendancePrice = value;
        RaisePropertyChanged(AttendancePricePropertyName);
      }
    }

    #endregion

    #region -- DisplayItemList --

    public static string DisplayItemListPropertyName = "DisplayItemList";
    private BindingList<DisplayItem> _displayItemList;
    public BindingList<DisplayItem> DisplayItemList {
      get {
        return _displayItemList;
      }
      set {
        if (_displayItemList == value) {
          return;
        }

        _displayItemList = value;
        RaisePropertyChanged(DisplayItemListPropertyName);
      }
    }

    #endregion

    #region -- Total --

    public static string TotalPropertyName = "Total";
    private float _total;
    public float Total {
      get {
        return _total;
      }
      set {
        if (_total == value) {
          return;
        }

        _total = value;
        RaisePropertyChanged(TotalPropertyName);
      }
    }

    #endregion

    #endregion

    #region - Commands -

    #region -- BackCmd --

    private RelayCommand _backCmd;

    public RelayCommand BackCmd {
      get {
        return _backCmd;
      }
    }

    private RelayCommand<DisplayItem> _removeItemCommand;
    public RelayCommand<DisplayItem> RemoveItemCommand {
      get { return _removeItemCommand; }
    }

    #endregion

    #endregion

    #region - Public Methods -

    public event ChangeWindowEventHandler OnChangeWindow;

    public RefreshUserViewSumDelegate UserViewSumRefresh { get; set; }

    #endregion

    #region - Private Methods -

    #region -- InitializeData --

    private void InitializeData() {

      InitializeAttendancePrice();
      InitializeDisplayItemList();
      InitializeTotal();

      InitializeCommands();
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      _backCmd = new RelayCommand(ExecuteBackCmd, CanExecuteBackCmd);
      _removeItemCommand = new RelayCommand<DisplayItem>(ExecuteRemoveItem);
    }

    #endregion

    #region -- ExecuteBackCmd --

    private void ExecuteBackCmd() {

      if (OnChangeWindow == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.USER, false, User);
      OnChangeWindow(this, args);

    }

    private bool CanExecuteBackCmd() {
      return true;
    }

    #endregion

    #region ExecuteRemoveItem

    private void ExecuteRemoveItem(DisplayItem displayItem) {
      var purchaseList = Global.DataService.Purchases.Where(x => x.PurchaseUserRef.UserId == User.UserId && x.PurchaseEventInventoryRef.EventIntenvotryItemRef.ItemName == displayItem.DisplayItemName).ToList();

      Purchase itemToRemove = null;

      if (purchaseList.Count > 0) {
        itemToRemove = purchaseList.FirstOrDefault();
        Global.DataService.Purchases.Remove(itemToRemove);
      }

      Global.DataService.SaveChanges();
      Global.DataService.Purchases.Load();
      InitializeDisplayItemList();
      InitializeTotal();
      UserViewSumRefresh();
    }

    private bool CanExecuteRemoveItem() {
      return true;
    }

    #endregion

    #region -- InitializeAttendancePrice --

    private void InitializeAttendancePrice() {
      var attendance = Global.DataService.Attendances.Where(x => x.AttendanceUserRef.UserId == User.UserId && x.AttendanceEventRef.EventId == _event.EventId).FirstOrDefault();

      if (attendance != null) {

        var eventPrice = Global.DataService.EventPrices.Local.Where(x => x.EventPriceAttendanceTypeRef.AttendanceTypeId == attendance.AttendanceAttendanceTypeRef.AttendanceTypeId && x.EventPriceEventRef.EventId == _event.EventId).FirstOrDefault();

        if (eventPrice != null) {
          AttendancePrice = eventPrice.EventPriceValue;
        }
      }
    }

    #endregion

    #region -- InitializeDisplayItemList --

    private void InitializeDisplayItemList() {


        DisplayItemList = new BindingList<DisplayItem>(Global.DataService.EventInventories.Local.Where(x => x.EventInventoryEventRef.EventId == _event.EventId).Select(x => new DisplayItem(x)).ToList());

        foreach (var displayItem in DisplayItemList) {
          displayItem.DisplayItemAmount = Global.DataService.Purchases.Local.Where(x => x.PurchaseEventInventoryRef.EventInventoryId == displayItem.GetEventInventory().EventInventoryId && x.PurchaseUserRef.UserId == User.UserId).Count();
        }

        DisplayItemList = new BindingList<DisplayItem>(DisplayItemList.Where(x => x.DisplayItemAmount != 0).ToList());


    }

    #endregion

    #region -- InitializeTotal --

    private void InitializeTotal() {

      Total = AttendancePrice;

      foreach (DisplayItem displayItem in DisplayItemList) {

        Total += displayItem.DisplayItemTotal;

      }
    }

    #endregion

    #endregion

  }
}
