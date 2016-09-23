using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Connector;
using NoobApp.Entity;
using NoobApp.Enum;
using NoobApp.Event;
using NoobApp.Model;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace NoobApp.ViewModel {
  public class PurchaseViewModel : ViewModelBase {

    #region - Instance Variables -

    private readonly Entity.Event _event;

    #endregion

    #region - Constructor -

    public PurchaseViewModel(User user, Entity.Event eventEntity) {
      User = user;
      _event = eventEntity;

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

    #region -- DisplayItemList --

    public static string PurchaseDisplayItemListPropertyName = "PurchaseDisplayItemList";
    private BindingList<DisplayItem> _displayItemList;
    public BindingList<DisplayItem> PurchaseDisplayItemList {
      get {
        return _displayItemList;
      }
      set {
        if (_displayItemList == value) {
          return;
        }

        _displayItemList = value;
        RaisePropertyChanged(PurchaseDisplayItemListPropertyName);
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

        if (CanExecuteSaveCmd()) {
          ExecuteSaveCmd();
        }
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
      var entityList = Global.DataService.EventInventories.Local.Where(x => x.EventInventoryEventRef.EventId == _event.EventId);
      PurchaseDisplayItemList = new BindingList<DisplayItem>(entityList.Select(x => new DisplayItem(x)).ToList());

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

      SavePurchase();

      //if (OnChangeWindow == null) {
      //  return;
      //}

      //UserControlEventArgs args = new UserControlEventArgs(Views.USER, false, User);
      //OnChangeWindow(this, args);

    }

    private bool CanExecuteSaveCmd() {
      return true;
    }

    #endregion

    #region -- ExecuteCancelCmd --

    private void ExecuteCancelCmd() {

      if (OnChangeWindow == null) {
        return;
      }

      UserControlEventArgs args = new UserControlEventArgs(Views.USER, true, User);
      OnChangeWindow(this, args);

    }

    private bool CanExecuteCancelCmd() {
      return true;
    }

    #endregion

    #region -- SavePurchase --

    private void SavePurchase() {
      var purchase = new Purchase() {
        PurchaseBilled = false,
        PurchaseEventInventoryRef = DisplayItemSelected.GetEventInventory(),
        PurchaseUserRef = User,
      };

      Global.DataService.SaveChanges();
    }

    #endregion

    #endregion

  }
}
