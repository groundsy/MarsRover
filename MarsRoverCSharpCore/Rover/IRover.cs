using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverCSharp.Core.LandingSurface;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core.Rover
{
    public interface IRover
    {
        Point Position { get; set; }
        Direction Direction { get; set; }
        bool IsDeployed();
        void Deploy(ILandingSurface landingSurface, Point point, Direction direction);
        void Move(IEnumerable<Movement> movements);
        string Report();
    }
}
