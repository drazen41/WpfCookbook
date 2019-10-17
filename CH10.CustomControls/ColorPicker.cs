using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CH10.CustomControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CH10.CustomControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CH10.CustomControls;assembly=CH10.CustomControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ColorPicker/>
    ///
    /// </summary>
    public class ColorPicker : Control
    {
        ColorToBrushConverter _color2brush = new ColorToBrushConverter();
        ColorToDoubleConverter _color2double = new ColorToDoubleConverter();
        static ColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));
        }
        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorPicker),
                new UIPropertyMetadata(Colors.Black, OnSelectedColorChanged));

        private static void OnSelectedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var cp = (ColorPicker)d;
            cp.RaiseEvent(new RoutedPropertyChangedEventArgs<Color>((Color)e.OldValue, (Color)e.NewValue, SelectedColorChangedEvent));

        }

        public static RoutedEvent SelectedColorChangedEvent = EventManager.RegisterRoutedEvent("SelectedColorChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));
        public event RoutedPropertyChangedEventHandler<Color> SelectedColorChanged
        {
            add { AddHandler(SelectedColorChangedEvent, value); }
            remove { RemoveHandler(SelectedColorChangedEvent, value); }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            // bind component shapes
            BindShape("PART_RedShape", "r");
            BindShape("PART_GreenShape", "g");
            BindShape("PART_BlueShape", "b");
            BindShape("PART_AlphaShape", "a");
            // bind sliders
            BindSlider("PART_RedSlider", "r");
            BindSlider("PART_GreenSlider", "g");
            BindSlider("PART_BlueSlider", "b");
            BindSlider("PART_AlphaSlider", "a");
            // bind text blocks
            BindText("PART_RedText", "r", "R: {0}");
            BindText("PART_GreenText", "g", "G: {0}");
            BindText("PART_BlueText", "b", "B: {0}");
            BindText("PART_AlphaText", "a", "A: {0}");
            // bind main color
            var solidBrush = GetTemplateChild("PART_SelectedColor")
            as SolidColorBrush;
            if (solidBrush != null)
            {
                var binding = new Binding("SelectedColor");
                binding.Source = this;
                BindingOperations.SetBinding(solidBrush,
                SolidColorBrush.ColorProperty, binding);
            }
        }
        void BindShape(string partName, string parameter)
        {
            var shape = GetTemplateChild(partName) as Shape;
            if (shape == null) return;
            var binding = new Binding("SelectedColor");
            binding.Source = this;
            binding.Converter = _color2brush;
            binding.ConverterParameter = parameter;
            shape.SetBinding(Shape.FillProperty, binding);
        }
        void BindSlider(string partName, string parameter)
        {
            var slider = GetTemplateChild(partName) as RangeBase;
            if (slider == null) return;
            var binding = new Binding("SelectedColor");
            binding.Source = this;
            binding.Converter = _color2double;
            binding.ConverterParameter = parameter;
            binding.Mode = BindingMode.TwoWay;
            slider.SetBinding(RangeBase.ValueProperty, binding);
        }
        void BindText(string partName, string parameter, string format)
        {
            var tb = GetTemplateChild(partName) as TextBlock;
            if (tb == null) return;
            var binding = new Binding("SelectedColor");
            binding.Source = this;
            binding.Converter = _color2double;
            binding.ConverterParameter = parameter;
            binding.StringFormat = format;
            tb.SetBinding(TextBlock.TextProperty, binding);
        }
    }
}
