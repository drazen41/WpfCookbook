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
using System.Threading;


namespace CH11.AsyncCalcWithCS5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource _cts;
        public MainWindow()
        {
            InitializeComponent();
        }
        async Task<int> CountPrimesAsync(int first,int last,CancellationToken ct, IProgress<double> progress)
        {
            var task = Task.Run(() =>
            {
                int total = 0;
                int range = last - first + 1;
                int pcount = 0;
                for (int i = first; i <= last; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    bool isPrime = true;
                    int limit = (int)Math.Sqrt(i);
                    for (int j = 2; j <= limit; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                        
                    }
                    if (isPrime)
                        total++;
                    if (++pcount % 1000 == 0)
                        progress.Report(pcount * 100.0 / range);
                }
                return total;
            });
            return await task;
        }

        private async void _calcButton_Click(object sender, RoutedEventArgs e)
        {
            int first = int.Parse(_from.Text), last = int.Parse(_to.Text);
            _cts = new CancellationTokenSource();
            _calcButton.IsEnabled = false;
            _cancelButton.IsEnabled = true;
            _result.Text = "Calculating...";
            var progress = new Progress<double>(value => _progress.Value = value);
            try
            {
                int count = await CountPrimesAsync(first, last, _cts.Token, progress);
                _result.Text = "Total primes: " + count;
            }
            catch (OperationCanceledException ex)
            {
                _result.Text = "Operation cancelled";
                
            }
            finally
            {
                _cts.Dispose();
                _calcButton.IsEnabled = true;
                _cancelButton.IsEnabled = false;
            }
        }

        private void _cancelButton_Click(object sender, RoutedEventArgs e)
        {
            _cts.Cancel(); 
        }
    }
}
