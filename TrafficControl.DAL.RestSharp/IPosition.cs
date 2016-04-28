using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    public interface IPosition
    {
        Position GetPosition(int id=0);
        bool DeletePosition(int id);
        ICollection<Position> GetPositions();
        bool UpdatePosition(Position position);
    }
}
