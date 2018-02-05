using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public class SunnyFactory : IWeatherFactory
    {
        public IWeather GetWeather()
        {
            return new Sunny();
        }
    }

    public class RainyFactory : IWeatherFactory
    {
        public IWeather GetWeather()
        {
            return new Rainy();
        }
    }

    public class WindyFactory : IWeatherFactory
    {
        public IWeather GetWeather()
        {
            return new Windy();
        }
    }
}
