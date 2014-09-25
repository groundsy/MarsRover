using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverCSharp.Core.Rover;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core
{
    public static class ExtensionMethods
    {
        public static string ToReportString(this Direction direction)
        {   
            // Convert a direction to its string representation.
            switch (direction)
            {
                case Direction.North:
                    return "N";
                case Direction.East:
                    return "E";
                case Direction.South:
                    return "S";
                case Direction.West:
                    return "W";
                default:
                    return "";
            }
        }
    }
}
