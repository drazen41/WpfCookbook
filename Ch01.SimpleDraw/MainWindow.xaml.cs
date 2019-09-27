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

namespace Ch01.SimpleDraw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point _pos;
        bool _isDrawing;
        Brush _stroke = Brushes.Black;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void _root_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rect = e.Source as Rectangle;
            if (rect != null)
            {
                _stroke = rect.Fill;
            }
            else
            {
                _isDrawing = true;
                _pos = e.GetPosition(_root);
                _root.CaptureMouse();
            }
            
        }

        private void _root_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing)
            {
                Line line = new Line();
                line.X1 = _pos.X;
                line.Y1 = _pos.Y;
                _pos = e.GetPosition(_root);
                line.X2 = _pos.X;
                line.Y2 = _pos.Y;
                line.Stroke = _stroke;
                line.StrokeThickness = 1;
                _root.Children.Add(line);
            }
        }

        private void _root_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDrawing = false;
            _root.ReleaseMouseCapture();
        }
    }
}
