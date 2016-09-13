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

    #endregion

    #region - Public Methods -

    public event ChangeWindowEventHandler OnUserSelected;

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

    #region -- ChangeWindow --

    private void OpenUserView() {

      if (OnUserSelected == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.USER, false, UserSelected);
      OnUserSelected(this, args);

    }

    #endregion

    #endregion

  }
}
