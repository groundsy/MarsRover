using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core.LandingSurface
{
    [Serializable]
    public class LandingSurfaceSizeException : Exception
    {
        public LandingSurfaceSizeException(string message): base(message)
        {
        }
    }
}
