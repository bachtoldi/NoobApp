using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using NoobApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public delegate void ChangeWindowCommand();
    public event ChangeWindowCommand ChangeWindow;

    #endregion

    #region - Private Methods -

    #region -- InitializeData --

    private void InitializeData() {
      InitializeCommands();

      InitializeDummyData();
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      _selectUserCmd = new RelayCommand(ExecuteSelectUserCmd, CanExecuteSelectUserCmd);
    }

    #endregion

    #region -- ExecuteSelectUserCmd --

    private void ExecuteSelectUserCmd() {
      int i = 0;
    }

    private bool CanExecuteSelectUserCmd() {
      return true;
    }

    #endregion

    #region -- InitializeDummyData --

    private void InitializeDummyData() {
      UserList = new BindingList<User>();

      UserList.Add(new User() { UserId = 1, UserFirstName = "Pascal", UserLastName = "Schneider", UserDisplayName = "BACHTOLDI", });
      UserList.Add(new User() { UserId = 2, UserFirstName = "Michi", UserLastName = "Rickli", UserDisplayName = "Gnorsh", });
      UserList.Add(new User() { UserId = 3, UserFirstName = "Beni", UserLastName = "Käslin", UserDisplayName = "Prelmoid", });
      UserList.Add(new User() { UserId = 4, UserFirstName = "Donat", UserLastName = "Roduner", UserDisplayName = "Skatanic", });
      UserList.Add(new User() { UserId = 5, UserFirstName = "Oli", UserLastName = "Bachem", UserDisplayName = "DrNoEscape", });
      UserList.Add(new User() { UserId = 6, UserFirstName = "Lukas", UserLastName = "Tuggener", UserDisplayName = "Schnidlauch", });
    }

    #endregion

    #endregion

  }
}
