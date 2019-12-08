using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculatrice.CustomControls
{
    /// <summary>
    /// Interaction logic for DirectionalControl.xaml
    /// </summary>
    public partial class DirectionalControl : UserControl
    {
        public static readonly DependencyProperty DirectionControlTemplateShapeFillProperty = DependencyProperty.Register(
            "DirectionControlTemplateShapeFill", typeof(Brush), typeof(DirectionalControl), new PropertyMetadata(Brushes.CornflowerBlue));
        public string DirectionControlTemplateShapeFill
        {
            get { return (string)this.GetValue(DirectionControlTemplateShapeFillProperty); }
            set { this.SetValue(DirectionControlTemplateShapeFillProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlTemplateShapeStrokeProperty = DependencyProperty.Register(
         "DirectionControlTemplateShapeStroke", typeof(Brush), typeof(DirectionalControl), new PropertyMetadata(Brushes.DarkGray));
        public string DirectionControlTemplateShapeStroke
        {
            get { return (string)this.GetValue(DirectionControlTemplateShapeStrokeProperty); }
            set { this.SetValue(DirectionControlTemplateShapeStrokeProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlTemplateShapeStrokeThicknessProperty = DependencyProperty.Register(
        "DirectionControlTemplateShapeStrokeThickness", typeof(int), typeof(DirectionalControl), new PropertyMetadata(5));
        public string DirectionControlTemplateShapeStrokeThickness
        {
            get { return (string)this.GetValue(DirectionControlTemplateShapeStrokeThicknessProperty); }
            set { this.SetValue(DirectionControlTemplateShapeStrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlTemplateTriangleTextProperty = DependencyProperty.Register(
            "DirectionControlTemplateTriangleText", typeof(string), typeof(DirectionalControl), new PropertyMetadata("undefined"));
        public string DirectionControlTemplateTriangleText
        {
            get { return (string)this.GetValue(DirectionControlTemplateTriangleTextProperty); }
            set { this.SetValue(DirectionControlTemplateTriangleTextProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlTemplateTriangleSizeProperty = DependencyProperty.Register(
            "DirectionControlTemplateTriangleSize", typeof(double), typeof(DirectionalControl), new PropertyMetadata(5.0));
        public string DirectionControlTemplateTriangleSize
        {
            get { return (string)this.GetValue(DirectionControlTemplateTriangleSizeProperty); }
            set { this.SetValue(DirectionControlTemplateTriangleSizeProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlTemplateTriangleForegroundProperty = DependencyProperty.Register(
          "DirectionControlTemplateTriangleForeground", typeof(Brush), typeof(DirectionalControl), new PropertyMetadata(Brushes.Red));
        public string DirectionControlTemplateTriangleForeground
        {
            get { return (string)this.GetValue(DirectionControlTemplateTriangleForegroundProperty); }
            set { this.SetValue(DirectionControlTemplateTriangleForegroundProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlScaleTransformScaleXProperty = DependencyProperty.Register(
            "DirectionControlScaleTransformScaleX", typeof(double), typeof(DirectionalControl), new PropertyMetadata(1.0));
        public string DirectionControlScaleTransformScaleX
        {
            get { return (string)this.GetValue(DirectionControlScaleTransformScaleXProperty); }
            set { this.SetValue(DirectionControlScaleTransformScaleXProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlScaleTransformScaleYProperty = DependencyProperty.Register(
            "DirectionControlScaleTransformScaleY", typeof(double), typeof(DirectionalControl), new PropertyMetadata(1.0));
        public string DirectionControlScaleTransformScaleY
        {
            get { return (string)this.GetValue(DirectionControlScaleTransformScaleYProperty); }
            set { this.SetValue(DirectionControlScaleTransformScaleYProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlScrewTransformAngleXProperty = DependencyProperty.Register(
            "DirectionControlScrewTransformAngleX", typeof(double), typeof(DirectionalControl), new PropertyMetadata(0.0));
        public string DirectionControlScrewTransformAngleX
        {
            get { return (string)this.GetValue(DirectionControlScrewTransformAngleXProperty); }
            set { this.SetValue(DirectionControlScrewTransformAngleXProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlScrewTransformAngleYProperty = DependencyProperty.Register(
            "DirectionControlScrewTransformAngleY", typeof(double), typeof(DirectionalControl), new PropertyMetadata(0.0));
        public string DirectionControlScrewTransformAngleY
        {
            get { return (string)this.GetValue(DirectionControlScrewTransformAngleYProperty); }
            set { this.SetValue(DirectionControlScrewTransformAngleYProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlTranslateTransformXProperty = DependencyProperty.Register(
            "DirectionControlTranslateTransformX", typeof(double), typeof(DirectionalControl), new PropertyMetadata(0.0));
        public string DirectionControlTranslateTransformX
        {
            get { return (string)this.GetValue(DirectionControlTranslateTransformXProperty); }
            set { this.SetValue(DirectionControlTranslateTransformXProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlTranslateTransformYProperty = DependencyProperty.Register(
            "DirectionControlTranslateTransformY", typeof(double), typeof(DirectionalControl), new PropertyMetadata(0.0));
        public string DirectionControlTranslateTransformY
        {
            get { return (string)this.GetValue(DirectionControlTranslateTransformYProperty); }
            set { this.SetValue(DirectionControlTranslateTransformYProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlRotateTransformAngleProperty = DependencyProperty.Register(
            "DirectionControlRotateTransformAngle", typeof(double), typeof(DirectionalControl), new PropertyMetadata(0.0));
        public string DirectionControlRotateTransformAngle
        {
            get { return (string)this.GetValue(DirectionControlRotateTransformAngleProperty); }
            set { this.SetValue(DirectionControlRotateTransformAngleProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlRotateTransformCenterXProperty = DependencyProperty.Register(
            "DirectionControlRotateTransformCenterX", typeof(double), typeof(DirectionalControl), new PropertyMetadata(0.0));
        public string DirectionControlRotateTransformCenterX
        {
            get { return (string)this.GetValue(DirectionControlRotateTransformCenterXProperty); }
            set { this.SetValue(DirectionControlRotateTransformCenterXProperty, value); }
        }

        public static readonly DependencyProperty DirectionControlRotateTransformCenterYProperty = DependencyProperty.Register(
            "DirectionControlRotateTransformCenterY", typeof(double), typeof(DirectionalControl), new PropertyMetadata(0.0));
        public string DirectionControlRotateTransformCenterY
        {
            get { return (string)this.GetValue(DirectionControlRotateTransformCenterYProperty); }
            set { this.SetValue(DirectionControlRotateTransformCenterYProperty, value); }
        }

        public DirectionalControl()
        {
            InitializeComponent();
        }
    }
}
