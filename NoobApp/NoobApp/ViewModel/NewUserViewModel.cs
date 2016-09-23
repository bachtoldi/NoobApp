using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Entity;
using NoobApp.Enum;
using NoobApp.Event;
using NoobApp.Model;
using System.Data.Entity;

namespace NoobApp.ViewModel {
  public class NewUserViewModel : ViewModelBase {

    #region - Instance Variables -

    #endregion

    #region - Constructor -

    public NewUserViewModel() {
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

    #region -- UserFirstName --

    public static string UserFirstNamePropertyName = "UserFirstName";
    public string UserFirstName {
      get {
        return _user.UserFirstName;
      }
      set {
        if (_user.UserFirstName == value) {
          return;
        }

        _user.UserFirstName = value;
        RaisePropertyChanged(UserFirstNamePropertyName);
        RaiseCanExecuteChanged();
      }
    }

    #endregion

    #region -- UserLastName --

    public static string UserLastNamePropertyName = "UserLastName";
    public string UserLastName {
      get {
        return _user.UserLastName;
      }
      set {
        if (_user.UserLastName == value) {
          return;
        }

        _user.UserLastName = value;
        RaisePropertyChanged(UserLastNamePropertyName);
        RaiseCanExecuteChanged();
      }
    }

    #endregion

    #region -- UserDisplayName --

    public static string UserDisplayNamePropertyName = "UserDisplayName";
    public string UserDisplayName {
      get {
        return _user.UserDisplayName;
      }
      set {
        if (_user.UserDisplayName == value) {
          return;
        }

        _user.UserDisplayName = value;
        RaisePropertyChanged(UserDisplayNamePropertyName);
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
      User = new User();
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

      SaveUser();

      if (OnChangeWindow == null) {
        return;
      }

      var args = new UserControlEventArgs(Views.HOME, false, null);
      OnChangeWindow(this, args);

    }

    private bool CanExecuteSaveCmd() {
      var canSave = true;

      if (User.UserFirstName == null || User.UserFirstName == string.Empty) {
        canSave = false;
      } else if (User.UserLastName == null || User.UserLastName == string.Empty) {
        canSave = false;
      } else if (User.UserDisplayName == null || User.UserDisplayName == string.Empty) {
        canSave = false;
      }

      return canSave;
    }

    #endregion

    #region -- ExecuteCancelCmd --

    private void ExecuteCancelCmd() {

      if (OnChangeWindow == null) {
        return;
      }

      var args = new UserControlEventArgs(Views.HOME, true, null);
      OnChangeWindow(this, args);


    }

    private bool CanExecuteCancelCmd() {
      return true;
    }

    #endregion

    #region -- SaveUser --

    private void SaveUser() {
      //Global.DataService.Entry(User).State = (User.UserId == 0) ? EntityState.Added : EntityState.Modified;
      Global.DataService.SaveChanges();
    }

    #endregion

    #region -- RaiseCanExecuteChanged --

    private void RaiseCanExecuteChanged() {
      _saveCmd.RaiseCanExecuteChanged();
    }

    #endregion

    #endregion

  }
}
