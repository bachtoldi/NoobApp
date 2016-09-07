using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Connector;
using NoobApp.Entity;
using NoobApp.Enum;
using NoobApp.Event;
using System;
using System.ComponentModel;
using System.Linq;

namespace NoobApp.ViewModel {
  public class PurchasedViewModel : ViewModelBase {

    #region - Instance Variables -

    #endregion

    #region - Constructor -

    public PurchasedViewModel(User user) {
      User = user;

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

    #region -- CalculateAttendancePrice --

    private void InitializeAttendancePrice() {

      var attendance = DummyDataConnector.Attendance1;
      attendance.AttendanceAttendanceTypeRef = DummyDataConnector.AttendanceType1;

      if (attendance != null) {
        var eventPrice = DummyDataConnector.GetEventPriceList().Where(x => x.EventPriceEventRef.EventId == attendance.AttendanceEventRef.EventId && x.EventPriceAttendanceTypeRef.AttendanceTypeId == attendance.AttendanceAttendanceTypeRef.AttendanceTypeId).FirstOrDefault();

        if (eventPrice != null) {
          AttendancePrice = eventPrice.EventPriceValue;
        }
      }

    }

    #endregion

    #region -- InitializeDisplayItemList --

    private void InitializeDisplayItemList() {

      DisplayItemList = new BindingList<DisplayItem>(DummyDataConnector.GetEventInventoryList().Select(x => new DisplayItem(x)).ToList());

      var random = new Random();

      foreach (var di in DisplayItemList) {
        di.DisplayItemAmount = random.Next(1, 21);
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
