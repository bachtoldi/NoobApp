using GalaSoft.MvvmLight;
using NoobApp.Entity;
using NoobApp.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobApp.ViewModel {
  public class UserViewModel : ViewModelBase {

    #region - Instance Variables -

    #endregion

    #region - Constructor -

    public UserViewModel(User user) {

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

    #endregion

  }
}
