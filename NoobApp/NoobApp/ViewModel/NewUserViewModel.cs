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

    public NewUserViewModel(User user) {
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

    #region -- DialogResult --

    public static string DialogResultPropertyName = "DialogResult";
    private bool? _dialogResult;
    public bool? DialogResult {
      get {
        return _dialogResult;
      }
      set {
        if (_dialogResult == value) {
          return;
        }

        _dialogResult = value;
        RaisePropertyChanged(DialogResultPropertyName);
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
      User.UserDisplayName = string.Empty;
      User.UserLastName = string.Empty;

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

      Global.DataService.Entry(User).State = EntityState.Added;

      Global.DataService.SaveChanges();

      DialogResult = true;
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
      User.UserFirstName = string.Empty;
      User.UserLastName = "1";
      User.UserDisplayName = "Neuer Teilnehmer";

      DialogResult = false;
    }

    private bool CanExecuteCancelCmd() {
      return true;
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
