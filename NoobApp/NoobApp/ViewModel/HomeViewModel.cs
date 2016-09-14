using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using NoobApp.Entity;
using NoobApp.Enum;
using NoobApp.Event;
using NoobApp.Model;
using System.ComponentModel;
using System.Data.Entity;

namespace NoobApp.ViewModel {
  public class HomeViewModel : ViewModelBase {

    #region - Instance Variables -

    #endregion

    #region - Constructor -

    public HomeViewModel() {
      InitializeData();
    }

    #endregion

    #region - Properties -

    #region -- UserList --

    public static string UserListPropertyName = "UserList";
    private BindingList<User> _userList;
    public BindingList<User> UserList {
      get {
        return _userList;
      }
      set {
        if (_userList == value) {
          return;
        }

        _userList = value;
        RaisePropertyChanged(UserListPropertyName);
      }
    }

    #endregion

    #region -- UserSelected --

    public static string UserSelectedPropertyName = "UserSelected";
    private User _userSelected;
    public User UserSelected {
      get {
        return _userSelected;
      }
      set {
        if (_userSelected == value) {
          return;
        }

        _userSelected = value;
        RaisePropertyChanged(UserSelectedPropertyName);

        if (CanExecuteSelectUserCmd()) {
          ExecuteSelectUserCmd();
        }
      }
    }

    #endregion

    #endregion

    #region - Commands -

    #region -- SelectUserCmd --

    private RelayCommand _selectUserCmd;

    public RelayCommand SelectUserCmd {
      get {
        return _selectUserCmd;
      }
    }

    #endregion

    #region -- NewUserCmd --

    private RelayCommand _newUserCmd;

    public RelayCommand NewUserCmd {
      get {
        return _newUserCmd;
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
        dataService.Users.Load();
        UserList = dataService.Users.Local.ToBindingList();
      }

      InitializeCommands();

    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      _selectUserCmd = new RelayCommand(ExecuteSelectUserCmd, CanExecuteSelectUserCmd);
      _newUserCmd = new RelayCommand(ExecuteNewUserCmd, CanExecuteNewUserCmd);
    }

    #endregion

    #region -- ExecuteSelectUserCmd --

    private void ExecuteSelectUserCmd() {
      OpenUserView();
    }

    private bool CanExecuteSelectUserCmd() {
      return true;
    }

    #endregion

    #region -- ExecuteNewUserCmd --

    private void ExecuteNewUserCmd() {
      OpenNewUserView();
    }

    private bool CanExecuteNewUserCmd() {
      return true;
    }

    #endregion

    #region -- OpenUserView --

    private void OpenUserView() {

      if (OnChangeWindow == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.USER, false, UserSelected);
      OnChangeWindow(this, args);

    }

    #endregion

    #region -- OpenNewUserView --

    private void OpenNewUserView() {

      if(OnChangeWindow == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.NEWUSER, false, null);
      OnChangeWindow(this, args);

    }
    
    #endregion

    #endregion

  }
}
