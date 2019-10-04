using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06.WeatherForecast
{
    public enum GeneralForecast
    {
        Sunny, Rainy, Snowy, Cloudy, Dry
    }
    public class Forecast
    {
        
        public GeneralForecast GeneralForecast { get; set; }
        public double TemperatureHigh { get; set; }
        public double TemperatureLow { get; set; }
        public double Percipitation { get; set; }
    }
}
