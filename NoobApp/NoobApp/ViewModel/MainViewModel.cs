using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Connector;
using NoobApp.Entity;
using NoobApp.Event;
using NoobApp.View;
using System.Windows;

namespace NoobApp.ViewModel {
  public class MainViewModel : ViewModelBase {

    #region - Instance Variables -



    #endregion

    #region - Constructor -

    public MainViewModel() {
      InitializeData();
      InitializeCommands();
    }

    #endregion

    #region - Properties -

    #region -- ContentControlView --

    public static string ContentControlViewPropertyName = "ContentControlView";
    private FrameworkElement _contentControlView;
    public FrameworkElement ContentControlView {
      get {
        return _contentControlView;
      }
      set {
        if(_contentControlView == value) {
          return;
        }

        _contentControlView = value;
        RaisePropertyChanged(ContentControlViewPropertyName);
      }
    }

    #endregion

    #endregion

    #region - Commands -

    #region -- HomeCmd --

    private RelayCommand _homeCmd;

    public RelayCommand HomeCmd {
      get {
        return _homeCmd;
      }
    }

    #endregion

    #region -- PopulateDatabaseCmd --

    private RelayCommand _populateDatabaseCmd;

    public RelayCommand PopulateDatabaseCmd{
      get {
        return _populateDatabaseCmd;
      }
    }

    #endregion


    #endregion

    #region - Public Methods -



    #endregion

    #region - Private Methods -

    #region -- InitializeData --

    private void InitializeData() {
      ExecuteHomeCmd();
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      _homeCmd = new RelayCommand(ExecuteHomeCmd, CanExecuteHomeCmd);
      _populateDatabaseCmd = new RelayCommand(ExecutePopulateDatabaseCmd, CanExecutePopulateDatabaseCmd);

    }

    #endregion

    #region -- HomeCmd --

    private void ExecuteHomeCmd() {
      HomeViewModel viewModel = new HomeViewModel();
      HomeView view = new HomeView(viewModel);

      ContentControlView = view;

      viewModel.OnUserSelected += new ChangeWindowEventHandler(ChangeWindow);
    }

    private bool CanExecuteHomeCmd() {
      return true;
    }

    #endregion

    #region -- PopulateDatabaseCmd --

    private void ExecutePopulateDatabaseCmd() {

      var userList = DummyDataConnector.GetUserList();
      var inventoryItemsList = DummyDataConnector.GetEventInventoryList();
      using (var dataConnector = new DataConnector()) {

        foreach (var user in userList) {

          dataConnector.Users.Add(user);
        }

        foreach(var inventoryItem in inventoryItemsList) {
          dataConnector.EventInventories.Add(inventoryItem);
        }

        dataConnector.SaveChanges();
      }
    }

    private bool CanExecutePopulateDatabaseCmd() {
      return true;
    }

    #endregion


    #region -- ChangeWindow --

    private void ChangeWindow(object sender, UserControlEventArgs e) {

      if(e.View == Views.USER) {

        UserViewModel viewModel = new UserViewModel(((HomeViewModel)sender).UserSelected);
        UserView view = new UserView(viewModel);

        ContentControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      } else if(e.View == Views.PURCHASE) {

        PurchaseViewModel viewModel = new PurchaseViewModel(((UserViewModel)sender).User);
        PurchaseView view = new PurchaseView(viewModel);

        ContentControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      } else if(e.View == Views.ATTENDANCE) {

        AttendanceViewModel viewModel = new AttendanceViewModel(((UserViewModel)sender).User);
        AttendanceView view = new AttendanceView(viewModel);

        ContentControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      } else if(e.View == Views.PURCHASED) {

        PurchasedViewModel viewModel = new PurchasedViewModel(((UserViewModel)sender).User);
        PurchasedView view = new PurchasedView(viewModel);

        ContentControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      }

    }

    #endregion

    #endregion

  }

}