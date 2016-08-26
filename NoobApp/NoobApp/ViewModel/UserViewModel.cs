using GalaSoft.MvvmLight;
using NoobApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobApp.ViewModel {
  public class UserViewModel : ViewModelBase {

    public UserViewModel(User user) {

    }

    #region - Public Methods -

    public event ChangeWindowEventHandler OnChangeWindow;

    #endregion

  }
}
