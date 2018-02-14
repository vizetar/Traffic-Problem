using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public class ShortestPathFactory : IShortestPathFactory
    {

        IOrbitFactory orbit;
        double craters = 0;
        double time = 0;
        double speed = 0;
        Orbits orbit_result;
        Dictionary<Orbits, Vehicles> vehiclesList = new Dictionary<Orbits, Vehicles>();

        IVehicleFactory vehicle;
        double vehicleSpeed = 0;
        double timetocrosscrater = 0;
        Vehicles vehicle_result;

        public ResponseModel GetPath(IList<RequestModel> request, Weather weatherType)
        {
            var vehicles = GetResources.FindWeather(weatherType).GetWeather().AllowedVehicles();

            foreach (var req in request)
            {
                speed = req.Speed;
                foreach (var res in vehicles)
                {
                    var _vehicle = GetResources.FindVehicle(res);
                    if (vehicleSpeed == 0 || _vehicle.GetVehicle().Speed() >= speed)
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
                vehiclesList.Add(req.Orbit, vehicle_result);
                vehicleSpeed = 0;
                timetocrosscrater = 0;
            }

            foreach (var req in request)
            {
                var _orbit = GetResources.FindOrbit(req.Orbit);
                var getVehicle = vehiclesList.GetValueOrDefault(req.Orbit);
                var orbitVehicle = GetResources.FindVehicle(getVehicle);

                var distance = _orbit.GetOrbit().Distance();
                var _time = distance / req.Speed;
                
                var _craters = _orbit.GetOrbit().TotalCraters();
                var cratersIncrease = _craters * (GetResources.FindWeather(weatherType).GetWeather().CraterIncrease() / 100);
                var cratersReduce = _craters * (GetResources.FindWeather(weatherType).GetWeather().CraterReduce() / 100);
                _craters = _craters + cratersIncrease - cratersReduce;

                //var cratertime = orbitVehicle.GetVehicle().TimeToCrossPerCrater() * _craters;

                if (_time <= time || time == 0)
                {
                    if (_craters < craters || craters == 0)
                    {
                        orbit_result = req.Orbit;
                        time = _time;
                        orbit = _orbit;
                        speed = req.Speed;
                        craters = _craters;
                    }
                }
            }

            vehicle_result = vehiclesList.GetValueOrDefault(orbit_result);

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
