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
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      _selectUserCmd = new RelayCommand(ExecuteSelectUserCmd, CanExecuteSelectUserCmd);
    }

    #endregion

    #region -- ExecuteSelectUserCmd --

    private void ExecuteSelectUserCmd() {

    }

    private bool CanExecuteSelectUserCmd() {
      return false;
    }

    #endregion

    #endregion

  }
}
