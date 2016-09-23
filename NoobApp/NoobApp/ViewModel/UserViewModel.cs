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
    private float _total;

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
      }
    }

    #endregion


    #endregion

    #region - Commands -

    #endregion

    #region - Public Methods -

    public event ChangeWindowEventHandler OnChangeWindow;

    #endregion

    #region - Private Methods -

    #region -- InitializeData --

    private void InitializeData() {
      InitialzieAttendance();
      InitializeCommands();
    }

    private void InitialzieAttendance() {

        AttendanceTypeList = Global.DataService.AttendanceTypes.Local.ToBindingList();

        _attendance = Global.DataService.Attendances.Where(x => x.AttendanceUserRef.UserId == User.UserId && x.AttendanceEventRef.EventId == _event.EventId).FirstOrDefault();

        if (_attendance != null) {
          AttendanceTypeSelected = AttendanceTypeList.Where(x => x.AttendanceTypeId == _attendance.AttendanceAttendanceTypeRef.AttendanceTypeId).FirstOrDefault();
        }

    }

    private string CalcSum() {
      return string.Empty;
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
    }

    #endregion

    #endregion

  }
}
