using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core.Rover
{
    [Serializable]
    public class RoverDeployException : Exception
    {
        public RoverDeployException(string message) : base(message)
        {
        }
    }
}
