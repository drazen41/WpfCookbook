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

namespace CH08.DataTriggerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new List<Book> {
new Book { BookName = "Windows Internals",
AuthorName = "Mark Russinovich", IsFree = false },
new Book { BookName = "AJAX Introduction",
AuthorName = "Bhanwar Gupta", IsFree = true },
new Book { BookName = "Essential COM",
AuthorName = "Don Box", IsFree = false },
new Book {
BookName = "Blueprint for a Successful Presentation",
AuthorName = "Biswajit Tripathy", IsFree = true }
        };
        }
    }
}
