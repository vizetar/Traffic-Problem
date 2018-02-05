using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public interface IShortestPathFactory
    {
        ResponseModel GetPath(IList<RequestModel> request, Weather weatherType);
    }

    
}
