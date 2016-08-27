using GalaSoft.MvvmLight;
using NoobApp.Entity;
using NoobApp.Event;

namespace NoobApp.ViewModel {
  public class PurchasedViewModel : ViewModelBase {

    #region - Instance Variables -

    #endregion

    #region - Constructor -

    public PurchasedViewModel(User user) {
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

    }

    #endregion

    #endregion

  }
}
