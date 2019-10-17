using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CH10.UserControls
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public ColorPicker()
        {
            InitializeComponent();
        }
        static ColorPicker()
        {
            CommandManager.RegisterClassCommandBinding(typeof(ColorPicker), new CommandBinding(MediaCommands.ChannelUp, ChannelUpExecute,
                ChannelUpCanExecute));
            CommandManager.RegisterClassCommandBinding(typeof(ColorPicker), new CommandBinding(MediaCommands.ChannelDown,
                ChannelDownExecute, ChannelDownCanExecute));
        }

        private static void ChannelDownCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var color = ((ColorPicker)sender).SelectedColor;
            e.CanExecute = color.R > 0 || color.G > 0 || color.B > 0;
        }

        private static void ChannelDownExecute(object sender, ExecutedRoutedEventArgs e)
        {
            var cp = (ColorPicker)sender;
            var color = cp.SelectedColor;
            if (color.R > 0) color.R--;
            if (color.G > 0) color.G--;
            if (color.B > 0) color.B--;
            cp.SelectedColor = color;
        }

        private static void ChannelUpCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var color = ((ColorPicker)sender).SelectedColor;
            e.CanExecute = color.R < 255 || color.G < 255 || color.B < 255;
        }

        private static void ChannelUpExecute(object sender, ExecutedRoutedEventArgs e)
        {
            var cp = (ColorPicker)sender;
            var color = cp.SelectedColor;
            if (color.R < 255) color.R++;
            if (color.G < 255) color.G++;
            if (color.B < 255) color.B++;
            cp.SelectedColor = color;
        }

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorPicker), 
                new UIPropertyMetadata(Colors.Black,OnSelectedChanged));

        private static void OnSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var cp = (ColorPicker)d;
            cp.RaiseEvent(new RoutedPropertyChangedEventArgs<Color>((Color)e.OldValue, (Color)e.NewValue,SelectedColorChangedEvent));

        }

        public static RoutedEvent SelectedColorChangedEvent = EventManager.RegisterRoutedEvent("SelectedColorChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));
        public event RoutedPropertyChangedEventHandler<Color>SelectedColorChanged
        {
            add { AddHandler(SelectedColorChangedEvent, value); }
            remove { RemoveHandler(SelectedColorChangedEvent, value); }
        }
    }
}
