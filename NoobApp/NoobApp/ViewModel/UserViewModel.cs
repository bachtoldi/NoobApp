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
  public class UserViewModel : ViewModelBase {

    #region - Instance Variables -

    private Entity.Event _event;
    private Attendance _attendance;

    #endregion

    #region - Constructor -

    public UserViewModel(User user, Entity.Event noobEvent) {
      User = user;

      _event = noobEvent;

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

    #region -- AttendanceTypeList --

    public static string AttendanceTypeListPropertyName = "AttendanceTypeList";
    private BindingList<AttendanceType> _attendanceTypeList;
    public BindingList<AttendanceType> AttendanceTypeList {
      get {
        return _attendanceTypeList;
      }
      set {
        if (_attendanceTypeList == value) {
          return;
        }

        _attendanceTypeList = value;
        RaisePropertyChanged(AttendanceTypeListPropertyName);
      }
    }

    #endregion

    #region -- AttendanceTypeSelected --

    public static string AttendanceTypeSelectedPropertyName = "AttendanceTypeSelected";
    private AttendanceType _attendanceTypeSelected;
    public AttendanceType AttendanceTypeSelected {
      get {
        return _attendanceTypeSelected;
      }
      set {
        if (_attendanceTypeSelected == value) {
          return;
        }

        _attendanceTypeSelected = value;
        RaisePropertyChanged(AttendanceTypeSelectedPropertyName);

        if(CanExecuteUserAttendanceTypeSelected() && _attendanceTypeSelected != null) {
          ExecuteUserAttendanceTypeSelected();
        }
      }
    }

    #endregion

    #region -- Total --

    public static string TotalPropertyName = "Total";
    private string _total;
    public string Total {
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

    #region -- ShowUserPurchasesCmd --

    public static string ShowUserPurchasesCmdPropertyName = "ShowUserPurchasesCmd";
    private RelayCommand _showUserPurchasesCmd;
    public RelayCommand ShowUserPurchasesCmd {
      get {
        return _showUserPurchasesCmd;
      }
      set {
        if (_showUserPurchasesCmd == value) {
          return;
        }

        _showUserPurchasesCmd = value;
        RaisePropertyChanged(ShowUserPurchasesCmdPropertyName);
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
      InitialzieAttendance();
      CalcSum();
      InitializeCommands();
    }

    private void InitialzieAttendance() {
        AttendanceTypeList = Global.DataService.AttendanceTypes.Local.ToBindingList();

        _attendance = Global.DataService.Attendances.Where(x => x.AttendanceUserRef.UserId == User.UserId && x.AttendanceEventRef.EventId == _event.EventId).FirstOrDefault();

        if (_attendance != null) {
          _attendanceTypeSelected = AttendanceTypeList.Where(x => x.AttendanceTypeId == _attendance.AttendanceAttendanceTypeRef.AttendanceTypeId).FirstOrDefault();
        }

    }

    public void CalcSum() {
      var purchases = Global.DataService.Purchases.Where(x => x.PurchaseUserRef.UserId == User.UserId && x.PurchaseEventInventoryRef.EventInventoryEventRef.EventId == _event.EventId).Sum(y => y.PurchaseEventInventoryRef.EventInventoryPrice);
      float attendancePrice = 0.0f;

      var attendance = Global.DataService.Attendances.Where(x => x.AttendanceUserRef.UserId == User.UserId && x.AttendanceEventRef.EventId == _event.EventId).FirstOrDefault();
      if (attendance != null) {
        attendancePrice = Global.DataService.EventPrices.Local.Where(x => x.EventPriceAttendanceTypeRef.AttendanceTypeId == attendance.AttendanceAttendanceTypeRef.AttendanceTypeId && x.EventPriceEventRef.EventId == _event.EventId).FirstOrDefault().EventPriceValue;
      }

      Total = (purchases + attendancePrice).ToString();
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      ShowUserPurchasesCmd = new RelayCommand(ExecuteShowUserPurchasesCmd, CanExecuteShowUserPurchasesCmd);
    }

    #endregion

    #region -- ExecuteUserAttendanceTypeSelected --

    private void ExecuteUserAttendanceTypeSelected() {

      Attendance userAttendance = Global.DataService.Attendances.Where(x => x.AttendanceUserRef.UserId == User.UserId).FirstOrDefault();

      if(userAttendance != null) {
        userAttendance.AttendanceAttendanceTypeRef = AttendanceTypeSelected;
      }else {
        userAttendance = new Attendance() {
          AttendanceAttendanceTypeRef = AttendanceTypeSelected,
          AttendanceUserRef = User,
          AttendanceEventRef = _event,
        };
      }

      Global.DataService.Attendances.Add(userAttendance);
      Global.DataService.SaveChanges();
    }

    private bool CanExecuteUserAttendanceTypeSelected() { 
      return true;
    }

    #endregion

    #region -- ExecuteShowUserPurchasesCmd --

    private void ExecuteShowUserPurchasesCmd() {
      var eventArgs = new UserControlEventArgs(Views.PURCHASED, false, User);

      OnChangeWindow(this, eventArgs);
    }

    private bool CanExecuteShowUserPurchasesCmd() {
      return true;
    }

    #endregion

    #endregion

  }
}
