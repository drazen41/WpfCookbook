using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Ch06.SortingAndFiltering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Process.GetProcesses();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView(DataContext);
            view.SortDescriptions.Clear();
            if (_sortField.SelectedValue != null)
                view.SortDescriptions.Add(new SortDescription((string)
                _sortField.SelectedValue, _ascending.IsChecked == true ?
                ListSortDirection.Ascending :
                ListSortDirection.Descending));
        }

        private void OnFilter(object sender, RoutedEventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView(DataContext);
            if (string.IsNullOrWhiteSpace(_filterText.Text))
                view.Filter = null;
            else
                view.Filter = obj => ((Process)obj).ProcessName.IndexOf(_filterText.Text,StringComparison.InvariantCultureIgnoreCase) > -1;
        }
    }
}
