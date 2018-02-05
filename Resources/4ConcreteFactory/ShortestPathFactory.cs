using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public class ShortestPathFactory : IShortestPathFactory
    {

        IOrbitFactory orbit;
        int craters = 0;
        double time = 0;
        double speed = 0;
        Orbits orbit_result;

        IVehicleFactory vehicle;
        double vehicleSpeed = 0;
        double timetocrosscrater = 0;
        Vehicles vehicle_result;

        public ResponseModel GetPath(IList<RequestModel> request, Weather weatherType)
        {
            foreach (var req in request)
            {
                var _orbit = GetResources.FindOrbit(req.Orbit);
                var distance = _orbit.GetOrbit().Distance();
                var _time = distance / req.Speed;
                if (_time < time || time == 0)
                {
                    orbit_result = req.Orbit;
                    time = _time;
                    orbit = _orbit;
                    speed = req.Speed;
                    craters = orbit.GetOrbit().TotalCraters();
                }
            }

            var cratersIncrease = craters * (GetResources.FindWeather(weatherType).GetWeather().CraterIncrease() / 100);
            var cratersReduce = craters * (GetResources.FindWeather(weatherType).GetWeather().CraterReduce() / 100);
            craters = craters + cratersIncrease - cratersReduce;

            var vehicles = GetResources.FindWeather(weatherType).GetWeather().AllowedVehicles();

            foreach (var res in vehicles)
            {
                var _vehicle = GetResources.FindVehicle(res);
                if (vehicleSpeed == 0 ||  _vehicle.GetVehicle().Speed() >= speed)
                {
                    var totaltimetocrosscrater = _vehicle.GetVehicle().TimeToCrossPerCrater();
                    if (timetocrosscrater == 0 || totaltimetocrosscrater < timetocrosscrater)
                    {
                        vehicle_result = res;
                        vehicle = _vehicle;
                        vehicleSpeed = vehicle.GetVehicle().Speed();
                        timetocrosscrater = totaltimetocrosscrater;
                    }

                }

            }

            return new ResponseModel()
            {
                Orbit = orbit_result,
                Vehicle = vehicle_result
            };

        }

    }

    public static class GetResources
    {
        public static IOrbitFactory FindOrbit(Orbits orbitType)
        {
            switch (orbitType)
            {
                case Orbits.Orbit1:
                    return new Orbit1Factory();
                case Orbits.Orbit2:
                    return new Orbit2Factory();
                default:
                    return new Orbit2Factory();
            }
        }

        public static IWeatherFactory FindWeather(Weather weatherType)
        {
            switch (weatherType)
            {
                case Weather.Rainy:
                    return new RainyFactory();
                case Weather.Sunny:
                    return new SunnyFactory();
                case Weather.Windy:
                    return new WindyFactory();
                default:
                    return new RainyFactory();
            }
        }

        public static IVehicleFactory FindVehicle(Vehicles vehicleType)
        {
            switch (vehicleType)
            {
                case Vehicles.Bike:
                    return new BikeFactory();
                case Vehicles.Car:
                    return new CarFactory();
                case Vehicles.Tuktuk:
                    return new TukTukFactory();
                default:
                    return new TukTukFactory();
            }
        }
    }
}
