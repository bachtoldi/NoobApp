using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Entity;
using NoobApp.Enum;
using NoobApp.Event;
using NoobApp.Model;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace NoobApp.ViewModel {
  public class AttendanceViewModel : ViewModelBase {

    #region - Instance Variables -

    private Entity.Event _event;
    private Attendance _attendance;

    #endregion

    #region - Constructor -

    public AttendanceViewModel(User user, Entity.Event eventValue) {
      User = user;
      _event = eventValue;

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

    #region -- FromDateTime --

    public static string FromDateTimePropertyName = "FromDateTime";
    private DateTime? _fromDateTime;
    public DateTime? FromDateTime {
      get {
        return _fromDateTime;
      }
      set {
        if (_fromDateTime == value) {
          return;
        }

        _fromDateTime = value;
        RaisePropertyChanged(FromDateTimePropertyName);
        RaiseCanExecuteChanged();
      }
    }

    #endregion

    #region -- TillDateTime --

    public static string TillDateTimePropertyName = "TillDateTime";
    private DateTime? _tillDateTime;
    public DateTime? TillDateTime {
      get {
        return _tillDateTime;
      }
      set {
        if (_tillDateTime == value) {
          return;
        }

        _tillDateTime = value;
        RaisePropertyChanged(TillDateTimePropertyName);
        RaiseCanExecuteChanged();
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

      using (var dataService = new DataService()) {
        dataService.AttendanceTypes.Load();
        AttendanceTypeList = new BindingList<AttendanceType>(dataService.AttendanceTypes.Local);

        dataService.Attendances.Load();
        _attendance = dataService.Attendances.Where(x => x.AttendanceUserRef.UserId == User.UserId).FirstOrDefault();

        if (_attendance != null) {
          AttendanceTypeSelected = AttendanceTypeList.Where(x => x.AttendanceTypeId == _attendance.AttendanceAttendanceTypeRef.AttendanceTypeId).FirstOrDefault();
          FromDateTime = _attendance.AttendanceStartDateTime;
          TillDateTime = _attendance.AttendanceEndDateTime;
        }
      }

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

      SaveAttendance();

      if (OnChangeWindow == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.USER, false, User);
      OnChangeWindow(this, args);

    }

    private bool CanExecuteSaveCmd() {
      return (_fromDateTime != null && _tillDateTime != null && _attendanceTypeSelected != null);
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

    #region -- SaveAttendance --

    private void SaveAttendance() {

      if (_attendance == null) {
        _attendance = new Attendance() {
          AttendanceStartDateTime = FromDateTime.Value,
          AttendanceEndDateTime = TillDateTime.Value,
          AttendanceAttendanceTypeRef = AttendanceTypeSelected,
          AttendanceEventRef = _event,
          AttendanceUserRef = User,
        };
      } else {
        _attendance.AttendanceStartDateTime = FromDateTime.Value;
        _attendance.AttendanceEndDateTime = TillDateTime.Value;
        _attendance.AttendanceAttendanceTypeRef = AttendanceTypeSelected;
      }

      using (var dataService = new DataService()) {
        dataService.Entry(_attendance).State = (_attendance.AttendanceId == 0) ? EntityState.Added : EntityState.Modified;
        dataService.SaveChanges();
      }

    }

    #endregion

    #region -- RaiseCanExecuteChanged --

    private void RaiseCanExecuteChanged() {
      if (_saveCmd != null) { _saveCmd.RaiseCanExecuteChanged(); }
      if (_cancelCmd != null) { _cancelCmd.RaiseCanExecuteChanged(); }
    }

    #endregion

    #endregion

  }
}
