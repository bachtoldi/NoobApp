using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using NoobApp.Entity;
using NoobApp.Enum;
using NoobApp.Event;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

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

    public event ChangeWindowEventHandler OnChangeWindow;

    public void NewUserCallback() {
      AddDummyUser();
    }

    #endregion

    #region - Private Methods -

    #region -- InitializeData --

    private void InitializeData() {
      UserList = Global.DataService.Users.Local.ToBindingList();

      AddDummyUser();

      InitializeCommands();
    }

    private void AddDummyUser() {
      UserList.Add(new User() {
        UserDisplayName = "Neuer Teilnehmer",
        UserLastName = "1",
      });

      Global.DataService.Entry(UserList.Last()).State = EntityState.Unchanged;
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

      if (UserSelected.UserLastName.Equals("1")) {
        UserControlEventArgs newUserArgs = new UserControlEventArgs(Views.NEWUSER, false, UserSelected);
        OnChangeWindow(this, newUserArgs);
      }
        
      UserControlEventArgs args = new UserControlEventArgs(Views.USER, false, UserSelected);
      OnChangeWindow(this, args);

    }

    #endregion

    #region -- OpenNewUserView --

    private void OpenNewUserView() {

      if (OnChangeWindow == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.NEWUSER, false, UserSelected);
      OnChangeWindow(this, args);
    }

    #endregion

    #endregion

  }
}
