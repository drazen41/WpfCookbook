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

namespace Ch04.SelectingOptions
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

        private void OnMakeTea(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder("Tea: ");
            foreach (RadioButton rb in _teaTypePanel.Children)
                if (rb.IsChecked == true)
                {
                    sb.AppendLine(rb.Content.ToString());
                    break;
                }
            if (_isSugar.IsChecked == true)
                sb.AppendLine("With sugar");
            if (_isMilk.IsChecked == true)
                sb.AppendLine("With milk");
            if (_isLemon.IsChecked == true)
                sb.AppendLine("With lemon");
            if (_isLemon.IsChecked == true && _isMilk.IsChecked == true)
                sb.AppendLine("Very unusual!");
            MessageBox.Show(sb.ToString(), "Tea Maker");
        }
    }
}
