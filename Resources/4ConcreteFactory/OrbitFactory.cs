using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public class Orbit1Factory : IOrbitFactory
    {
        public IOrbit GetOrbit()
        {
            return new Orbit1();
        }
    }

    public class Orbit2Factory : IOrbitFactory
    {
        public IOrbit GetOrbit()
        {
            return new Orbit2();
        }
    }
}
