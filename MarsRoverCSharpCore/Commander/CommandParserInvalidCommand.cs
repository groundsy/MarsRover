using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core.Commander
{
    [Serializable]
    public class CommandParserInvalidCommand : Exception
    {
        public CommandParserInvalidCommand(string message) : base(message)
        {
        }
    }
}
