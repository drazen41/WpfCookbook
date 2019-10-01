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

namespace Ch03.PaintingCircles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickCanvas(object sender, MouseButtonEventArgs e)
        {
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    var circle = new Ellipse { Stroke = Brushes.Black, StrokeThickness = 3, Fill = Brushes.Red, Width = 30, Height = 30 };
                    var pos = e.GetPosition(_canvas);
                    Canvas.SetLeft(circle, pos.X - circle.Width / 2);
                    Canvas.SetTop(circle, pos.Y - circle.Height / 2);
                    _canvas.Children.Add(circle);
                    break;
                case MouseButton.Middle:
                    break;
                case MouseButton.Right:
                    var ellipse = e.Source as Ellipse;
                    if (ellipse != null)
                        _canvas.Children.Remove(ellipse);
                    break;
                    break;
                case MouseButton.XButton1:
                    break;
                case MouseButton.XButton2:
                    break;
                default:
                    break;
            }
        }
    }
}
