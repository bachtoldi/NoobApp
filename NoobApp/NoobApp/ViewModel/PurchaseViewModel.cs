using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Connector;
using NoobApp.Entity;
using NoobApp.Event;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace NoobApp.ViewModel {
  public class PurchaseViewModel : ViewModelBase {

    #region - Instance Variables -

    #endregion

    #region - Constructor -

    public PurchaseViewModel(User user) {
      User = user;

      InitializeData();

      InitializeCommands();
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

    #region -- TotalPurchase --

    public static string TotalPurchasePropertyName = "TotalPurchase";
    public float TotalPurchase {
      get {
        return DisplayItemList.Sum(x => x.DisplayItemTotal);
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

      using (var dataContext = new DataConnector()) {

        dataContext.EventInventories.Load();
         
        var eventInventories = dataContext.EventInventories.ToList();

        DisplayItemList = new BindingList<DisplayItem>(eventInventories.Select(x => new DisplayItem(x)).ToList());
      }

      //DisplayItemList = new BindingList<DisplayItem>(DummyDataConnector.GetEventInventoryList().Select(x => new DisplayItem(x)).ToList());
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

    }

    private bool CanExecuteSaveCmd() {
      return true;
      //(DisplayItemList.Sum(x => x.DisplayItemTotal) != 0);
    }

    #endregion

    #region -- ExecuteCancelCmd --

    private void ExecuteCancelCmd() {

    }

    private bool CanExecuteCancelCmd() {
      return true;
    }

    #endregion

    #endregion

  }
}
