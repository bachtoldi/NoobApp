using GalaSoft.MvvmLight;
using NoobApp.Connector;
using NoobApp.Entity;
using NoobApp.Event;
using System.ComponentModel;
using System.Linq;

namespace NoobApp.ViewModel {
  public class PurchaseViewModel : ViewModelBase {

    #region - Instance Variables -

    #endregion

    #region - Constructor -

    public PurchaseViewModel(User user) {
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

    #region -- DisplayItemList --

    public static string DisplayItemListPropertyName = "DisplayItemList";
    private BindingList<DisplayItem> _displayItemList;
    public BindingList<DisplayItem> DisplayItemList {
      get {
        return _displayItemList;
      }
      set {
        if (_displayItemList == value) {
          return;
        }

        _displayItemList = value;
        RaisePropertyChanged(DisplayItemListPropertyName);
      }
    }

    #endregion

    #region -- DisplayItemSelected --

    public static string DisplayItemSelectedPropertyName = "DisplayItemSelected";
    private DisplayItem _displayItemSelected;
    public DisplayItem DisplayItemSelected {
      get {
        return _displayItemSelected;
      }
      set {
        if (_displayItemSelected == value) {
          return;
        }

        _displayItemSelected = value;
        RaisePropertyChanged(DisplayItemSelectedPropertyName);
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
      DisplayItemList = new BindingList<DisplayItem>(DummyDataConnector.GetEventInventoryList().Select(x => new DisplayItem(x)).ToList());

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
