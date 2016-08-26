using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        if (_contentControlView == value) {
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

    #endregion

    #region - Public Methods -

    private ChangeWindowDelegate _changeWindowDelegate;
    public delegate void ChangeWindowDelegate(FrameworkElement element);

    public void AddChangeWindowDelegate(ChangeWindowDelegate changeWindowDelegate) {
      _changeWindowDelegate += changeWindowDelegate;
    }

    public void RemoveChangeWindowDelegate(ChangeWindowDelegate changeWindowDelegate) {
      _changeWindowDelegate -= changeWindowDelegate;
    }

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
    }

    #endregion

    #region -- HomeCmd --

    private void ExecuteHomeCmd() {
      HomeViewModel viewModel = new HomeViewModel();
      HomeView view = new HomeView(viewModel);

      ContentControlView = view;
    }

    private bool CanExecuteHomeCmd() {
      return true;
    }

    #endregion

    #endregion

  }
}