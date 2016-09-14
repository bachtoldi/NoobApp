using NoobApp.ViewModel;
using System.Windows.Controls;

namespace NoobApp.View {
  /// <summary>
  /// Interaction logic for NewUserView.xaml
  /// </summary>
  public partial class NewUserView : UserControl {
    public NewUserView(NewUserViewModel viewModel) {
      InitializeComponent();
      DataContext = viewModel;
    }
  }
}
