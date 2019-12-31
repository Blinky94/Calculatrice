using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculatrice.CustomControls
{
    /// <summary>
    /// Interaction logic for RosaryControl.xaml
    /// </summary>
    public partial class RosaryControl : UserControl
    {
        public RosaryControl()
        {
            InitializeComponent();
        }

        public event EventHandler<OnDirectionalClickedEventArgs> OnDirectionalClicked;

        public void DirectionalLeft_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnDirectionalClicked?.Invoke(this, new OnDirectionalClickedEventArgs(DirectionalLeft.Name));   
        }

        public void DirectionalDown_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnDirectionalClicked?.Invoke(this, new OnDirectionalClickedEventArgs(DirectionalDown.Name));
        }

        public void DirectionalRight_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnDirectionalClicked?.Invoke(this, new OnDirectionalClickedEventArgs(DirectionalRight.Name));
        }

        public void DirectionalUp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnDirectionalClicked?.Invoke(this, new OnDirectionalClickedEventArgs(DirectionalUp.Name));
        }
    }
}
