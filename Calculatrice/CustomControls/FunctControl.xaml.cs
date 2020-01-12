using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Calculatrice.CustomControls
{
    /// <summary>
    /// Logique d'interaction pour FunctControl.xaml
    /// </summary>
    public partial class FunctControl : UserControl
    {
        public static readonly DependencyProperty LeftLabelTextProperty = DependencyProperty.Register(
            "LeftLabelText", typeof(string), typeof(FunctControl), new PropertyMetadata("undefined"));
        public string LeftLabelText
        {
            get { return (string)this.GetValue(LeftLabelTextProperty); }
            set { this.SetValue(LeftLabelTextProperty, value); }
        }

        public static readonly DependencyProperty RightLabelTextProperty = DependencyProperty.Register(
           "RightLabelText", typeof(string), typeof(FunctControl), new PropertyMetadata("undefined"));
        public string RightLabelText
        {
            get { return (string)this.GetValue(RightLabelTextProperty); }
            set { this.SetValue(RightLabelTextProperty, value); }
        }

        public static readonly DependencyProperty FuncTextProperty = DependencyProperty.Register(
            "FuncText", typeof(string), typeof(FunctControl), new PropertyMetadata("undefined"));
        public string FuncText
        {
            get { return (string)this.GetValue(FuncTextProperty); }
            set { this.SetValue(FuncTextProperty, value); }
        }

        public static readonly DependencyProperty FuncHeightProperty = DependencyProperty.Register(
            "FuncHeight", typeof(double), typeof(FunctControl), new PropertyMetadata(30.0));
        public double FuncHeight
        {
            get { return (double)this.GetValue(FuncHeightProperty); }
            set { this.SetValue(FuncHeightProperty, value); }
        }

        public static readonly DependencyProperty FuncLabelHeightProperty = DependencyProperty.Register(
            "FuncLabelHeight", typeof(double), typeof(FunctControl), new PropertyMetadata(45.0));
        public double FuncLabelHeight
        {
            get { return (double)this.GetValue(FuncLabelHeightProperty); }
            set { this.SetValue(FuncLabelHeightProperty, value); }
        }

        public static readonly DependencyProperty FuncWidthProperty = DependencyProperty.Register(
            "FuncWidth", typeof(double), typeof(FunctControl), new PropertyMetadata(40.0));
        public double FuncWidth
        {
            get { return (double)this.GetValue(FuncWidthProperty); }
            set { this.SetValue(FuncWidthProperty, value); }
        }

        public static readonly DependencyProperty LeftLabelBackgroundProperty = DependencyProperty.Register(
            "LeftLabelBackground", typeof(Brush), typeof(FunctControl), new PropertyMetadata(Brushes.Red));
        public Brush LeftLabelBackground
        {
            get { return (Brush)this.GetValue(LeftLabelBackgroundProperty); }
            set { this.SetValue(LeftLabelBackgroundProperty, value); }
        }

        public static readonly DependencyProperty LeftLabelForegroundProperty = DependencyProperty.Register(
            "LeftLabelForeground", typeof(Brush), typeof(FunctControl), new PropertyMetadata(Brushes.Yellow));
        public Brush LeftLabelForeground
        {
            get { return (Brush)this.GetValue(LeftLabelForegroundProperty); }
            set { this.SetValue(LeftLabelForegroundProperty, value); }
        }

        public static readonly DependencyProperty RightLabelBackgroundProperty = DependencyProperty.Register(
            "RightLabelBackground", typeof(Brush), typeof(FunctControl), new PropertyMetadata(Brushes.Blue));
        public Brush RightLabelBackground
        {
            get { return (Brush)this.GetValue(RightLabelBackgroundProperty); }
            set { this.SetValue(RightLabelBackgroundProperty, value); }
        }

        public static readonly DependencyProperty RightLabelForegroundProperty = DependencyProperty.Register(
            "RightLabelForeground", typeof(Brush), typeof(FunctControl), new PropertyMetadata(Brushes.White));
        public Brush RightLabelForeground
        {
            get { return (Brush)this.GetValue(RightLabelForegroundProperty); }
            set { this.SetValue(RightLabelForegroundProperty, value); }
        }

        public static readonly DependencyProperty FuncBackgroundProperty = DependencyProperty.Register(
            "FuncBackground", typeof(Brush), typeof(FunctControl), new PropertyMetadata(Brushes.LightGray));
        public Brush FuncBackground
        {
            get { return (Brush)this.GetValue(FuncBackgroundProperty); }
            set { this.SetValue(FuncBackgroundProperty, value); }
        }

        public static readonly DependencyProperty LeftLabelSizeProperty = DependencyProperty.Register(
            "LeftLabelSize", typeof(double), typeof(FunctControl), new PropertyMetadata(1.0));
        public double LeftLabelSize
        {
            get { return (double)this.GetValue(LeftLabelSizeProperty); }
            set { this.SetValue(LeftLabelSizeProperty, value); }
        }

        public static readonly DependencyProperty RightLabelSizeProperty = DependencyProperty.Register(
            "RightLabelSize", typeof(double), typeof(FunctControl), new PropertyMetadata(1.0));
        public double RightLabelSize
        {
            get { return (double)this.GetValue(RightLabelSizeProperty); }
            set { this.SetValue(RightLabelSizeProperty, value); }
        }

        public static readonly DependencyProperty FuncTextSizeProperty = DependencyProperty.Register(
            "FuncTextSize", typeof(double), typeof(FunctControl), new PropertyMetadata(25.0));
        public double FuncTextSize
        {
            get { return (double)this.GetValue(FuncTextSizeProperty); }
            set { this.SetValue(FuncTextSizeProperty, value); }
        }

        public static readonly DependencyProperty FuncForegroundProperty = DependencyProperty.Register(
            "FuncForeground", typeof(Brush), typeof(FunctControl), new PropertyMetadata(Brushes.Black));
        public Brush FuncForeground
        {
            get { return (Brush)this.GetValue(FuncForegroundProperty); }
            set { this.SetValue(FuncForegroundProperty, value); }
        }

        public static readonly DependencyProperty FuncLabelLeftMarginProperty = DependencyProperty.Register(
            "FuncLabelLeftMargin", typeof(Thickness), typeof(FunctControl), new PropertyMetadata(default(Thickness)));
        public Thickness FuncLabelLeftMargin
        {
            get { return (Thickness)this.GetValue(FuncLabelLeftMarginProperty); }
            set { this.SetValue(FuncLabelLeftMarginProperty, value); }
        }

        public static readonly DependencyProperty FuncLabelRightMarginProperty = DependencyProperty.Register(
            "FuncLabelRightMargin", typeof(Thickness), typeof(FunctControl), new PropertyMetadata(default(Thickness)));
        public Thickness FuncLabelRightMargin
        {
            get { return (Thickness)this.GetValue(FuncLabelRightMarginProperty); }
            set { this.SetValue(FuncLabelRightMarginProperty, value); }
        }

        public static readonly DependencyProperty FuncButtonMarginProperty = DependencyProperty.Register(
            "FuncButtonMargin", typeof(Thickness), typeof(FunctControl), new PropertyMetadata(default(Thickness)));
        public Thickness FuncButtonMargin
        {
            get { return (Thickness)this.GetValue(FuncButtonMarginProperty); }
            set { this.SetValue(FuncButtonMarginProperty, value); }
        }

        public static readonly DependencyProperty FuncTextMarginProperty = DependencyProperty.Register(
            "FuncTextMargin", typeof(string), typeof(FunctControl), new PropertyMetadata("0 8 0 0"));
        public string FuncTextMargin
        {
            get { return (string)this.GetValue(FuncTextMarginProperty); }
            set { this.SetValue(FuncTextMarginProperty, value); }
        }

        public static readonly DependencyProperty FuncButtonCornerRadiusProperty = DependencyProperty.Register(
            "FuncButtonCornerRadius", typeof(CornerRadius), typeof(FunctControl), new PropertyMetadata(new CornerRadius(5.0)));
        public CornerRadius FuncButtonCornerRadius
        {
            get { return (CornerRadius)this.GetValue(FuncButtonCornerRadiusProperty); }
            set { this.SetValue(FuncButtonCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty FuncButtonBorderThicknessProperty = DependencyProperty.Register(
            "FuncButtonBorderThickness", typeof(double), typeof(FunctControl), new PropertyMetadata(0.7));
        public double FuncButtonBorderThickness
        {
            get { return (double)this.GetValue(FuncButtonBorderThicknessProperty); }
            set { this.SetValue(FuncButtonBorderThicknessProperty, value); }
        }

        public static readonly DependencyProperty FuncButtonIsCheckedProperty = DependencyProperty.Register(
            "FuncButtonIsChecked", typeof(bool), typeof(FunctControl), new PropertyMetadata(false));
        public bool FuncButtonIsChecked
        {
            get { return (bool)this.GetValue(FuncButtonIsCheckedProperty); }
            set { this.SetValue(FuncButtonIsCheckedProperty, value); }
        }

        public static readonly DependencyProperty FuncButtonNameProperty = DependencyProperty.Register(           
            "FuncButtonName", typeof(string), typeof(FunctControl), new PropertyMetadata("Undefined"));
        public string FuncButtonName
        {
            get { return (string)this.GetValue(FuncButtonNameProperty); }
            set { this.SetValue(FuncButtonNameProperty, value); }
        }

        public static readonly DependencyProperty FuncFontFamilyProperty = DependencyProperty.Register( 
            "FuncFontFamily", typeof(FontFamily), typeof(FunctControl), new PropertyMetadata(new FontFamily("punchlineFilled")));
        public FontFamily FuncFontFamily
        {
            get { return (FontFamily)this.GetValue(FuncFontFamilyProperty); }
            set { this.SetValue(FuncFontFamilyProperty, value); }
        }

        public event RoutedEventHandler ToggleButtonClick;
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonClick?.Invoke(this, new RoutedEventArgs());
        }

        public FunctControl()
        {
            InitializeComponent();


        }
    }
}
