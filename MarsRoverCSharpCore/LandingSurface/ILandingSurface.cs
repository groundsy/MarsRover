using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core.LandingSurface
{
    public interface ILandingSurface
    {
        Size GetSize();
        void SetSize(Size size);
        bool IsValidPoint(Point point);
    }
}
