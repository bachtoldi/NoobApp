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

      var args = new UserControlEventArgs(Views.USER, false, null);
      OnChangeWindow(this, args);

    }

    private bool CanExecuteSaveCmd() {
      return false;
    }

    #endregion

    #region -- ExecuteCancelCmd --

    private void ExecuteCancelCmd() {

      if (OnChangeWindow == null) {
        return;
      }

      var args = new UserControlEventArgs(Views.USER, true, null);
      OnChangeWindow(this, args);


    }

    private bool CanExecuteCancelCmd() {
      return true;
    }

    #endregion

    #region -- SaveUser --

    private void SaveUser() {

      using (var dataService = new DataService()) {

        dataService.Entry(User).State = (User.UserId == 0) ? EntityState.Added : EntityState.Modified;
        dataService.SaveChanges();

      }

    }

    #endregion

    #endregion

  }
}
