using Resources;
using System;
using System.Collections.Generic;

namespace ShortestPathApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Weather is ");
            var weathertype = Console.ReadLine();
            Weather weather = Enum.Parse<Weather>(weathertype);
            Console.WriteLine("Orbit1 traffic speed is ");
            var orbit1 = Console.ReadLine();
            Console.WriteLine("Orbit2 traffic speed is ");
            var orbit2 = Console.ReadLine();
            var requestModel = new List<Resources.RequestModel>()
            {
                new Resources.RequestModel()
                {
                    Orbit = Resources.Orbits.Orbit1,
                    Speed = Convert.ToInt16(orbit1)
                },
                new Resources.RequestModel()
                {
                    Orbit = Resources.Orbits.Orbit2,
                    Speed = Convert.ToInt16(orbit2)
                },
            };

            IShortestPathFactory factory = new ShortestPathFactory();
            var result = new Resources.Client(factory).GetShortestPath(requestModel, weather);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
