using NoobApp.ViewModel;
using System.Windows.Controls;

namespace NoobApp.View {
  /// <summary>
  /// Interaction logic for AttendanceView.xaml
  /// </summary>
  public partial class AttendanceView : UserControl {
    public AttendanceView(AttendanceViewModel viewModel) {
      InitializeComponent();
      DataContext = viewModel;
    }
  }
}
