using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace NoobApp.TriggerAction {
  public class IncreaseTextboxAction : TriggerAction<Button> {
    public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(TextBox), typeof(IncreaseTextboxAction), new UIPropertyMetadata(null));
    public TextBox Target {
      get { return (TextBox)GetValue(TargetProperty); }
      set { SetValue(TargetProperty, value); }
    }

    protected override void Invoke(object parameter) {
      int value;

      if (Int32.TryParse(Target.Text, out value)) {
        value++;
        Target.Text = value.ToString();
      }
    }
  }

  public class DecreaseTextboxAction : TriggerAction<Button> {
    public static readonly DependencyProperty TargetProperty =
      DependencyProperty.Register("Target", typeof(TextBox), typeof(DecreaseTextboxAction), new UIPropertyMetadata(null));

    public TextBox Target {
      get { return (TextBox)GetValue(TargetProperty); }
      set { SetValue(TargetProperty, value); }
    }

    protected override void Invoke(object parameter) {
      int value;

      if(Int32.TryParse(Target.Text, out value)) {
        value--;
        Target.Text = value.ToString();
      }
    }
  }
}
