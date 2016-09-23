using NoobApp.ViewModel;
using System.Windows;

namespace NoobApp.View {
  /// <summary>
  /// Interaction logic for NewUserView.xaml
  /// </summary>
  public partial class NewUserView : Window {
    public NewUserView(NewUserViewModel viewModel) {
      InitializeComponent();
      DataContext = viewModel;
    }
  }
}
