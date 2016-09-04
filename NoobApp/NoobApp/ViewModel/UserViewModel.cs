using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Entity;
using NoobApp.Enum;
using NoobApp.Event;

namespace NoobApp.ViewModel {
  public class UserViewModel : ViewModelBase {

    #region - Instance Variables -

    #endregion

    #region - Constructor -

    public UserViewModel(User user) {
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

    #endregion

    #region - Commands -

    #region -- AddPurchaseCmd --

    private RelayCommand _addPurchaseCmd;

    public RelayCommand AddPurchaseCmd {
      get {
        return _addPurchaseCmd;
      }
    }

    #endregion

    #region -- AttendanceCmd --

    private RelayCommand _attendanceCmd;

    public RelayCommand AttendanceCmd {
      get {
        return _attendanceCmd;
      }
    }

    #endregion

    #region -- ViewPurchasesCmd --

    private RelayCommand _viewPurchaseCmd;

    public RelayCommand ViewPurchasesCmd {
      get {
        return _viewPurchaseCmd;
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
      InitializeCommands();
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      _addPurchaseCmd = new RelayCommand(ExecuteAddPurchaseCmd, CanExecuteAddPurchaseCmd);
      _attendanceCmd = new RelayCommand(ExecuteAttendanceCmd, CanExecuteAttendanceCmd);
      _viewPurchaseCmd = new RelayCommand(ExecuteViewPurchaseCmd, CanExecuteViewPurchaseCmd);
    }

    #endregion

    #region -- ExecuteAddPurchaseCmd --

    private void ExecuteAddPurchaseCmd() {
      OpenAddPurchaseView();
    }

    private bool CanExecuteAddPurchaseCmd() {
      return (User != null);
    }

    #endregion

    #region -- ExecuteAttendanceCmd --

    private void ExecuteAttendanceCmd() {
      OpenAttendanceView();
    }

    private bool CanExecuteAttendanceCmd() {
      return (User != null);
    }

    #endregion

    #region -- ExecuteViewPurchaseCmd --

    private void ExecuteViewPurchaseCmd() {
      OpenViewPurchaseView();
    }

    private bool CanExecuteViewPurchaseCmd() {
      return (User != null);
    }

    #endregion

    #region -- OpenAddPurchaseView --

    private void OpenAddPurchaseView() {

      if(OnChangeWindow == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.PURCHASE, false, User);
      OnChangeWindow(this, args);

    }

    #endregion

    #region -- OpenAttendanceView --

    private void OpenAttendanceView() {

      if(OnChangeWindow == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.ATTENDANCE, false, User);
      OnChangeWindow(this, args);

    }

    #endregion

    #region -- OpenViewPurchaseView --

    private void OpenViewPurchaseView() {

      if(OnChangeWindow == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.PURCHASED, false, User);
      OnChangeWindow(this, args);

    }

    #endregion

    #endregion

  }
}
