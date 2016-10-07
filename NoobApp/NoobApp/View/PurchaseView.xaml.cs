using NoobApp.ViewModel;
using System.Windows.Controls;
using System;
using System.Windows.Input;
using System.Windows;

namespace NoobApp.View {
  /// <summary>
  /// Interaction logic for PurchaseView.xaml
  /// </summary>
  public partial class PurchaseView : UserControl {
    public PurchaseView(PurchaseViewModel viewModel) {
      InitializeComponent();
      DataContext = viewModel;
    }

    private void ListBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
      var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
      if (item != null) {
        ((PurchaseViewModel)DataContext).AddPurchase(((DisplayItem)item.Content));
      }
    }
  }
}
