using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Entity;
using NoobApp.Enum;
using NoobApp.Event;
using NoobApp.Model;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

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
        if(_user == value) {
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

    #endregion

    #endregion

    #region - Public Methods -

    public event ChangeWindowEventHandler OnChangeWindow;

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

    #region -- InitializeAttendancePrice --

    private void InitializeAttendancePrice() {

      using(var dataService = new DataService()) {

        dataService.Attendances.Load();
        var attendance = dataService.Attendances.Where(x => x.AttendanceUserRef.UserId == User.UserId && x.AttendanceEventRef.EventId == _event.EventId).FirstOrDefault();

        if(attendance != null) {
          dataService.EventPrices.Load();
          dataService.Events.Load();
          dataService.AttendanceTypes.Load();
          var eventPrice = dataService.EventPrices.Local.Where(x => x.EventPriceAttendanceTypeRef.AttendanceTypeId == attendance.AttendanceAttendanceTypeRef.AttendanceTypeId && x.EventPriceEventRef.EventId == _event.EventId).FirstOrDefault();

          if(eventPrice != null) {
            AttendancePrice = eventPrice.EventPriceValue;
          }
        }

      }

    }

    #endregion

    #region -- InitializeDisplayItemList --

    private void InitializeDisplayItemList() {

      using (var dataService = new DataService()) {

        dataService.EventInventories.Load();
        dataService.Events.Load();
        dataService.Items.Load();
        DisplayItemList = new BindingList<DisplayItem>(dataService.EventInventories.Local.Where(x=>x.EventInventoryEventRef.EventId == _event.EventId).Select(x => new DisplayItem(x)).ToList());

        dataService.Purchases.Load();
        dataService.Users.Load();
        foreach(var displayItem in DisplayItemList) {
          displayItem.DisplayItemAmount = dataService.Purchases.Local.Where(x => x.PurchaseEventInventoryRef.EventInventoryId == displayItem.GetEventInventory().EventInventoryId && x.PurchaseUserRef.UserId == User.UserId).Count();
        }

        DisplayItemList = new BindingList<DisplayItem>(DisplayItemList.Where(x => x.DisplayItemAmount != 0).ToList());

      }

    }

    #endregion

    #region -- InitializeTotal --

    private void InitializeTotal() {

      Total = AttendancePrice;

      foreach(DisplayItem displayItem in DisplayItemList) {

        Total += displayItem.DisplayItemTotal;

      }

    }

    #endregion

    #endregion

  }
}
