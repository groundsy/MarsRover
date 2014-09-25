using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MarsRoverCSharp.Core.LandingSurface;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core.Commander
{
    public interface IRoverSquadCommander
    {
        void DeployNewRover(string deployCommands, string exploreCommands);
        IList<string> GetRoverSquadReport();
        ILandingSurface GetLandingSurface();
    }
}
