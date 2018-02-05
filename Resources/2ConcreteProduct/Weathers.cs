using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public class Sunny : IWeather
    {
        public IList<Vehicles> AllowedVehicles()
        {
            return new List<Vehicles>()
            {
                Vehicles.Car,
                Vehicles.Bike,
                Vehicles.Tuktuk
            };
        }

        public int CraterIncrease()
        {
            return 0;
        }

        public int CraterReduce()
        {
            return 10;
        }
    }

    public class Rainy : IWeather
    {
        public IList<Vehicles> AllowedVehicles()
        {
            return new List<Vehicles>()
            {
                Vehicles.Car,
                Vehicles.Tuktuk
            };
        }

        public int CraterIncrease()
        {
            return 20;
        }

        public int CraterReduce()
        {
            return 0;
        }
    }

    public class Windy : IWeather
    {
        public IList<Vehicles> AllowedVehicles()
        {
            return new List<Vehicles>()
            {
                Vehicles.Car,
                Vehicles.Bike
            };
        }

        public int CraterIncrease()
        {
            return 0;
        }

        public int CraterReduce()
        {
            return 0;
        }
    }
}
