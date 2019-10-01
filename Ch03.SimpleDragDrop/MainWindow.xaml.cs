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

namespace Ch03.SimpleDragDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += delegate { InitObjects(); };
        }
        void InitObjects()
        {
            var rnd = new Random();
            const int width = 45, height = 45;
            for (int i = 0; i < 30; i++)
            {
                var shape = rnd.Next(10) > 4 ? (Shape)new Ellipse() : (Shape)new Rectangle();
                shape.Stroke = Brushes.Black;
                shape.StrokeThickness = 2;
                shape.Fill = rnd.Next(10) > 4 ? Brushes.Red :
                Brushes.LightBlue;
                shape.Width = width;
                shape.Height = height;
                Canvas.SetLeft(shape, rnd.NextDouble() *
                (_source.ActualWidth - width));
                Canvas.SetTop(shape, rnd.NextDouble() *
                (_source.ActualHeight - height));
                _source.Children.Add(shape);
            }
            
        }

        private void OnBeginDrag(object sender, MouseButtonEventArgs e)
        {
            var obj = e.Source as Shape;
            if (obj != null)
            {
                DragDrop.DoDragDrop(obj, obj, DragDropEffects.Move);
            }
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            var element = e.Data.GetData(e.Data.GetFormats()[0]) as UIElement;
            if (element != null)
            {
                _source.Children.Remove(element);
                _target.Children.Add(element);
            }
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Ellipse).FullName))
                e.Effects = DragDropEffects.Move;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }
    }
}
