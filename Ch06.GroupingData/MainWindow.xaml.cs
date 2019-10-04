using System;
using System.Collections.Generic;
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

namespace Ch06.GroupingData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var procs = Process.GetProcesses().Where(CanAccess);
            var view = CollectionViewSource.GetDefaultView(procs);
            view.GroupDescriptions.Add(new PropertyGroupDescription("PriorityClass"));
            DataContext = procs;
        }
        public static bool CanAccess(Process process)
        {
            try
            {
                var h = process.Handle;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
