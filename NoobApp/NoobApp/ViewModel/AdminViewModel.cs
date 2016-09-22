using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using NoobApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        if(_eventInventorySelected==value) {
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

    #region -- HasChanges --

    public static string HasChangesPropertyName = "HasChanges";
    private bool _hasChanges;
    public bool HasChanges {
      get {
        return _hasChanges;
      }
      set {
        if (_hasChanges == value) {
          return;
        }

        _hasChanges = value;
        RaisePropertyChanged(HasChangesPropertyName);
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

    #region -- BackCmd --

    private RelayCommand _backCmd;

    public RelayCommand BackCmd {
      get {
        return _backCmd;
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
      _saveCmd = new RelayCommand(ExecuteSaveCmd, CanExecuteSaveCmd);
      _cancelCmd = new RelayCommand(ExecuteCancelCmd, CanExecuteCancelCmd);
      _backCmd = new RelayCommand(ExecuteBackCmd, CanExecuteBackCmd);
    }

    #endregion

    #region -- SaveCmd --

    private void ExecuteSaveCmd() {

    }

    private bool CanExecuteSaveCmd() {
      return false;
    }

    #endregion

    #region -- CancelCmd --

    private void ExecuteCancelCmd() {

    }

    private bool CanExecuteCancelCmd() {
      return true;
    }

    #endregion

    #region -- BackCmd --

    private void ExecuteBackCmd() {

    }

    private bool CanExecuteBackCmd() {
      return true;
    }

    #endregion

    #endregion

  }
}
