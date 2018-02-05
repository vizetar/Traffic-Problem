using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public interface IWeather
    {
        IList<Vehicles> AllowedVehicles();
        int CraterReduce();
        int CraterIncrease();
    }
  
}
