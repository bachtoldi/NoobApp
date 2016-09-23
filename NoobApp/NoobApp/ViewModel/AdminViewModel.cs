using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using NoobApp.Entity;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace NoobApp.ViewModel {
  public class AdminViewModel : ViewModelBase {

    #region - Instance Variables -

    #endregion

    #region - Constructor -

    public AdminViewModel() {
      InitializeData();
    }

    #endregion

    #region - Properties -

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

    #region -- AttendanceType --
    
    #region --- AttendanceTypeList ---

    public static string AttendanceTypeListPropertyName = "AttendanceTypeList";
    private BindingList<AttendanceType> _attendanceTypeList;
    public BindingList<AttendanceType> AttendanceTypeList {
      get {
        return _attendanceTypeList;
      }
      set {
        if (_attendanceTypeList == value) {
          return;
        }

        _attendanceTypeList = value;
        RaisePropertyChanged(AttendanceTypeListPropertyName);
      }
    }

    #endregion

    #region --- AttendanceTypeSelected ---

    public static string AttendanceTypeSelectedPropertyName = "AttendanceTypeSelected";
    private AttendanceType _attendanceTypeSelected;
    public AttendanceType AttendanceTypeSelected {
      get {
        return _attendanceTypeSelected;
      }
      set {
        if (_attendanceTypeSelected == value) {
          return;
        }

        _attendanceTypeSelected = value;
        RaisePropertyChanged(AttendanceTypeSelectedPropertyName);
      }
    }

    #endregion

    #endregion

    #region -- Event -- 

    #region --- EventList ---

    public static string EventListPropertyName = "EventList";
    private BindingList<Entity.Event> _eventList;
    public BindingList<Entity.Event> EventList {
      get {
        return _eventList;
      }
      set {
        if (_eventList == value) {
          return;
        }

        _eventList = value;
        RaisePropertyChanged(EventListPropertyName);
      }
    }

    #endregion

    #region --- EventSelected ---

    public static string EventSelectedPropertyName = "EventSelected";
    private Entity.Event _eventSelected;
    public Entity.Event EventSelected {
      get {
        return _eventSelected;
      }
      set {
        if (_eventSelected == value) {
          return;
        }

        _eventSelected = value;
        RaisePropertyChanged(EventSelectedPropertyName);
      }
    }

    #endregion

    #endregion

    #region -- EventInventory --

    #region --- EventInventoryList ---

    public static string EventInventoryListPropertyName = "EventInventoryList";
    private BindingList<EventInventory> _eventInventoryList;
    public BindingList<EventInventory> EventInventoryList {
      get {
        return _eventInventoryList;
      }
      set {
        if (_eventInventoryList == value) {
          return;
        }

        _eventInventoryList = value;
        RaisePropertyChanged(EventInventoryListPropertyName);
      }
    }

    #endregion

    #region --- EventInventorySelected ---

    public static string EventInventorySelectedPropertyName = "EventInventoryList";
    private EventInventory _eventInventorySelected;
    public EventInventory EventInventorySelected {
      get {
        return _eventInventorySelected;
      }
      set {
        if (_eventInventorySelected == value) {
          return;
        }

        _eventInventorySelected = value;
        RaisePropertyChanged(EventInventorySelectedPropertyName);
      }
    }

    #endregion

    #endregion

    #region -- EventPrice --

    #region --- EventPriceList ---

    public static string EventPriceListPropertyName = "EventPriceList";
    private BindingList<EventPrice> _eventPriceList;
    public BindingList<EventPrice> EventPriceList {
      get {
        return _eventPriceList;
      }
      set {
        if (_eventPriceList == value) {
          return;
        }

        _eventPriceList = value;
        RaisePropertyChanged(EventPriceListPropertyName);
      }
    }

    #endregion

    #region --- EventPriceSelected ---

    public static string EventPriceSelectedPropertyName = "EventPriceSelected";
    private EventPrice _eventPriceSelected;
    public EventPrice EventPriceSelected {
      get {
        return _eventPriceSelected;
      }
      set {
        if (_eventPriceSelected == value) {
          return;
        }

        _eventPriceSelected = value;
        RaisePropertyChanged(EventPriceSelectedPropertyName);
      }
    }

    #endregion

    #endregion

    #region -- Item --
    
    #region --- ItemList ---

    public static string ItemListPropertyName = "ItemList";
    private BindingList<Item> _itemList;
    public BindingList<Item> ItemList {
      get {
        return _itemList;
      }
      set {
        if (_itemList == value) {
          return;
        }

        _itemList = value;
        RaisePropertyChanged(ItemListPropertyName);
      }
    }

    #endregion

    #region --- ItemSelected ---

    public static string ItemSelectedPropertyName = "ItemSelected";
    private Item _itemSelected;
    public Item ItemSelected {
      get {
        return _itemSelected;
      }
      set {
        if (_itemSelected == value) {
          return;
        }

        _itemSelected = value;
        RaisePropertyChanged(ItemSelectedPropertyName);
      }
    }

    #endregion

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

    #region -- AddAttendanceTypeCmd --

    private RelayCommand _addAttendanceTypeCmd;

    public RelayCommand AddAttendanceTypeCmd {
      get {
        return _addAttendanceTypeCmd;
      }
    }

    #endregion

    #region -- RemoveAttendanceTypeCmd --

    private RelayCommand _removeAttendanceTypeCmd;

    public RelayCommand RemoveAttendanceTypeCmd {
      get {
        return _removeAttendanceTypeCmd;
      }
    }

    #endregion

    #region -- AddEventCmd --

    private RelayCommand _addEventCmd;

    public RelayCommand AddEventCmd {
      get {
        return _addEventCmd;
      }
    }

    #endregion

    #region -- RemoveEventCmd --

    private RelayCommand _removeEventCmd;

    public RelayCommand RemoveEventCmd {
      get {
        return _removeEventCmd;
      }
    }

    #endregion

    #region -- AddItemCmd --

    private RelayCommand _addItemCmd;

    public RelayCommand AddItemCmd {
      get {
        return _addItemCmd;
      }
    }

    #endregion

    #region -- RemoveItemCmd --

    private RelayCommand _removeItemCmd;

    public RelayCommand RemoveItemCmd {
      get {
        return _removeItemCmd;
      }
    }

    #endregion

    #endregion

    #region - Private Methods -

    #region -- InitializeData --

    private void InitializeData() {
      InitializeAttendance();
      InitializeEvent();
      InitializeItem();

      InitializeCommands();
    }

    #endregion

    #region -- InitializeAttendance --

    private void InitializeAttendance() {
      AttendanceTypeList = Global.DataService.AttendanceTypes.Local.ToBindingList();
    }

    #endregion

    #region -- InitializeEvent --

    private void InitializeEvent() {
      EventList = Global.DataService.Events.Local.ToBindingList();
    }

    #endregion

    #region -- InitializeItem --

    private void InitializeItem() {
      ItemList = Global.DataService.Items.Local.ToBindingList();
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      _saveCmd = new RelayCommand(ExecuteSaveCmd, CanExecuteSaveCmd);
      _cancelCmd = new RelayCommand(ExecuteCancelCmd, CanExecuteCancelCmd);
      _addAttendanceTypeCmd = new RelayCommand(ExecuteAddAttendanceTypeCmd, CanExecuteAddAttendanceTypeCmd);
      _removeAttendanceTypeCmd = new RelayCommand(ExecuteRemoveAttendanceTypeCmd, CanExecuteRemoveAttendanceTypeCmd);
      _addEventCmd = new RelayCommand(ExecuteAddEventCmd, CanExecuteAddEventCmd);
      _removeEventCmd = new RelayCommand(ExecuteRemoveEventCmd, CanExecuteRemoveEventCmd);
      _addItemCmd = new RelayCommand(ExecuteAddItemCmd, CanExecuteAddItemCmd);
      _removeItemCmd = new RelayCommand(ExecuteRemoveItemCmd, CanExecuteRemoveItemCmd);
    }

    #endregion

    #region -- SaveCmd --

    private void ExecuteSaveCmd() {
      Global.DataService.SaveChanges();

      DialogResult = true;
    }

    private bool CanExecuteSaveCmd() {
      return true;
    }

    #endregion

    #region -- CancelCmd --

    private void ExecuteCancelCmd() {
      Global.Rollback();

      DialogResult = false;
    }

    private bool CanExecuteCancelCmd() {
      return true;
    }

    #endregion
    
    #region -- AddAttendanceTypeCmd --

    private void ExecuteAddAttendanceTypeCmd() {
      AttendanceTypeList.Add(new AttendanceType());
      AttendanceTypeSelected = AttendanceTypeList[AttendanceTypeList.Count() - 1];
    }

    private bool CanExecuteAddAttendanceTypeCmd() {
      return true;
    }

    #endregion

    #region -- RemoveAttendanceTypeCmd --

    private void ExecuteRemoveAttendanceTypeCmd() { 
      AttendanceTypeList.Remove(AttendanceTypeSelected);

    }

    private bool CanExecuteRemoveAttendanceTypeCmd() {
      return (AttendanceTypeSelected != null);
    }

    #endregion

    #region -- AddEventCmd --

    private void ExecuteAddEventCmd() {
      EventList.Add(new Entity.Event());
      EventSelected = EventList[EventList.Count() - 1];
    }

    private bool CanExecuteAddEventCmd() {
      return true;
    }

    #endregion

    #region -- RemoveEventCmd --

    private void ExecuteRemoveEventCmd() {
      EventList.Remove(EventSelected);
    }

    private bool CanExecuteRemoveEventCmd() {
      return (EventSelected != null);
    }

    #endregion

    #region -- AddItemCmd --

    private void ExecuteAddItemCmd() {
      ItemList.Add(new Item());
      ItemSelected = ItemList[ItemList.Count() - 1];
    }

    private bool CanExecuteAddItemCmd() {
      return true;
    }

    #endregion

    #region -- RemoveItemCmd --

    private void ExecuteRemoveItemCmd() {
      ItemList.Remove(ItemSelected);
    }

    private bool CanExecuteRemoveItemCmd() {
      return (ItemSelected != null);
    }

    #endregion

    #endregion

  }
}
