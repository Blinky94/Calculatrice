using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Data;
using System;
using Calculatrice.CustomControls;

namespace Calculatrice
{


    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
      
        #region Bouger la calculatrice

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            this.Opacity = 0.75F;
            base.OnMouseLeftButtonDown(e);
            // Begin dragging the window
            this.DragMove();
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            this.Opacity = 1F;
            base.OnMouseLeftButtonUp(e);
        }

        #endregion

        private void Alpha_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            snde.FuncButtonIsChecked = false;
        }

        private void Snde_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            alpha.FuncButtonIsChecked = false;
        }
    }
}
