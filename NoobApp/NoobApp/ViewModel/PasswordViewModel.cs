using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace NoobApp.ViewModel {
  public class PasswordViewModel : ViewModelBase {

    #region - Instance Variables -

    private readonly string _adminPassword = "wiga15";

    #endregion

    #region - Constructor -

    public PasswordViewModel() {
      InitializeData();
    }

    #endregion

    #region - Properties -

    #region -- Password --

    public static string PasswordPropertyName = "Password";
    private string _password;
    public string Password {
      private get {
        return _password;
      }
      set {
        if (_password == value) {
          return;
        }

        _password = value;
        RaisePropertyChanged(PasswordPropertyName);
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

    #region -- OkCmd --

    private RelayCommand _okCmd;

    public RelayCommand OkCmd {
      get {
        return _okCmd;
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

    #region - Private Methods -

    #region -- InitializeData --

    private void InitializeData() {
      InitializeCommands();
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      _okCmd = new RelayCommand(ExecuteOkCmd, CanExecuteOkCmd);
      _cancelCmd = new RelayCommand(ExecuteCancelCmd, CanExecuteCancelCmd);
    }

    #endregion

    #region -- OkCmd --

    private void ExecuteOkCmd() {
      DialogResult = (_adminPassword.Equals(_password)) ? true : false;
    }

    private bool CanExecuteOkCmd() {
      return true;
    }

    #endregion

    #region -- CancelCmd --

    private void ExecuteCancelCmd() {
      DialogResult = false;
    }

    private bool CanExecuteCancelCmd() {
      return true;
    }

    #endregion

    #endregion

  }
}
