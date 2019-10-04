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

namespace Ch06.WeatherForecast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _days.ItemsSource = Enumerable.Range(1, 10);
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var data = new List<Forecast>();
            int days = (int)_days.SelectedItem;
            var rnd = new Random();
            for (int i = 0; i < days; i++)
            {
                double temp = rnd.NextDouble() * 40 - 10;
                var forecast = new Forecast
                {
                    GeneralForecast = (GeneralForecast)rnd.Next(
                Enum.GetValues(typeof(GeneralForecast)).Length),
                    TemperatureLow = temp,
                    TemperatureHigh = temp + rnd.NextDouble() * 15,
                    Percipitation = rnd.Next(10) > 5 ? rnd.NextDouble() * 10 : 0
                };
                data.Add(forecast);
            }
            DataContext = data;
        }
    }
}
