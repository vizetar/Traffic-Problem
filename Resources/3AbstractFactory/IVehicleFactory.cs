using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public interface IVehicleFactory
    {
        IVehicle GetVehicle();
    }
}
