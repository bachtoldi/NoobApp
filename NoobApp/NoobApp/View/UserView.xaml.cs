using NoobApp.ViewModel;
using System.Windows.Controls;

namespace NoobApp.View {
  /// <summary>
  /// Interaction logic for UserView.xaml
  /// </summary>
  public partial class UserView : UserControl {
    public UserView(UserViewModel viewModel) {
      InitializeComponent();
      DataContext = viewModel;
    }
  }
}
