using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public class Client
    {
        private readonly IShortestPathFactory shortestPathFactory;
        public Client(IShortestPathFactory shortestPathFactory)
        {
            this.shortestPathFactory = shortestPathFactory;
        }

        public string GetShortestPath(IList<RequestModel> request, Weather weatherType)
        {
            var path = shortestPathFactory.GetPath(request, weatherType);
            var result = String.Format("Vehicle {0} by orbit {1}", path.Vehicle, path.Orbit);
            return result;
        }
    }
}
