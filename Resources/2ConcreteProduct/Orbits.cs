using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public class Orbit1 : IOrbit
    {
        public double Distance()
        {
            return 18;
        }

        public int TotalCraters()
        {
            return 20;
        }
    }

    public class Orbit2 : IOrbit
    {
        public double Distance()
        {
            return 20;
        }

        public int TotalCraters()
        {
            return 10;
        }
    }
}
