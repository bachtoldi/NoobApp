﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Connector;
using NoobApp.Entity;
using NoobApp.Enum;
using NoobApp.Event;
using NoobApp.Model;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace NoobApp.ViewModel {
  public class PurchaseViewModel : ViewModelBase {

    #region - Instance Variables -

    private readonly Entity.Event _event;

    #endregion

    #region - Constructor -

    public PurchaseViewModel(User user, Entity.Event eventEntity) {
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

    #endregion

    #region - Commands -

    #region -- SaveCmd --

    private RelayCommand _saveCmd;

    public RelayCommand SaveCmd {
      get {
        return _saveCmd;
      }
    }

    #endregion

    #region -- CancelCmd --

    private RelayCommand _cancelCmd;

    public RelayCommand CancelCmd {
      get {
        return _cancelCmd;
      }
    }

    #endregion

    #endregion

    #region - Public Methods -

    public event ChangeWindowEventHandler OnChangeWindow;

    #endregion

    #region - Private Methods -

    #region -- InitializeData --

    private void InitializeData() {
      //TODO kann man ohne das scheiss load die referenzen ranholen?
      //dataService.EventInventories.Load();
      //dataService.Events.Load();
      //dataService.Items.Load();
      DisplayItemList = new BindingList<DisplayItem>(Global.DataService.EventInventories.Local.Where(x => x.EventInventoryEventRef.EventId == _event.EventId).Select(x => new DisplayItem(x)).ToList());

      InitializeCommands();
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      _saveCmd = new RelayCommand(ExecuteSaveCmd, CanExecuteSaveCmd);
      _cancelCmd = new RelayCommand(ExecuteCancelCmd, CanExecuteCancelCmd);
    }

    #endregion

    #region -- ExecuteSaveCmd --

    private void ExecuteSaveCmd() {

      SavePurchase();

      if (OnChangeWindow == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.USER, false, User);
      OnChangeWindow(this, args);

    }

    private bool CanExecuteSaveCmd() {
      return true;
    }

    #endregion

    #region -- ExecuteCancelCmd --

    private void ExecuteCancelCmd() {

      if (OnChangeWindow == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.USER, true, User);
      OnChangeWindow(this, args);

    }

    private bool CanExecuteCancelCmd() {
      return true;
    }

    #endregion

    #region -- SavePurchase --

    private void SavePurchase() {
      foreach (var item in DisplayItemList) {
        if (item.DisplayItemAmount > 0) {
          for (int i = 0; i < item.DisplayItemAmount; i++) {
            var purchase = new Purchase() {
              PurchaseBilled = false,
              PurchaseEventInventoryRef = item.GetEventInventory(),
              PurchaseUserRef = User,

            };

            //Global.DataService.Entry(purchase.PurchaseEventInventoryRef).State = EntityState.Unchanged;
            //Global.DataService.Entry(purchase.PurchaseUserRef).State = EntityState.Unchanged;
            //Global.DataService.Entry(purchase).State = (purchase.PurchaseId == 0) ? EntityState.Added : EntityState.Modified;
            Global.DataService.SaveChanges();
          }
        }
      }
    }

    #endregion

    #endregion

  }
}
