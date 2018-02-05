using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public class Bike : IVehicle
    {
        public double Speed()
        {
            return 10;
        }

        public double TimeToCrossPerCrater()
        {
            return 2;
        }
    }

    public class TukTuk : IVehicle
    {
        public double Speed()
        {
            return 12;
        }

        public double TimeToCrossPerCrater()
        {
            return 1;
        }
    }

    public class Car : IVehicle
    {
        public double Speed()
        {
            return 20;
        }

        public double TimeToCrossPerCrater()
        {
            return 3;
        }
    }
}
