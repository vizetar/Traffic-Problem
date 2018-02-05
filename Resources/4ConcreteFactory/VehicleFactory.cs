using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public class BikeFactory : IVehicleFactory
    {
        public IVehicle GetVehicle()
        {
            return new Bike();
        }
    }

    public class TukTukFactory : IVehicleFactory
    {
        public IVehicle GetVehicle()
        {
            return new TukTuk();
        }
    }

    public class CarFactory : IVehicleFactory
    {
        public IVehicle GetVehicle()
        {
            return new Car();
        }
    }
}
