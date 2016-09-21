using NoobApp.ViewModel;
using System.Windows;

namespace NoobApp.View {
  /// <summary>
  /// Interaction logic for AdminView.xaml
  /// </summary>
  public partial class AdminView : Window {
    public AdminView(AdminViewModel viewModel) {
      InitializeComponent();
      DataContext = viewModel;
    }
  }
}
