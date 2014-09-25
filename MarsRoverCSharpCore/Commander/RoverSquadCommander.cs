using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MarsRoverCSharp.Core.Commander;
using MarsRoverCSharp.Core.LandingSurface;
using MarsRoverCSharp.Core.Rover;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core.Commander
{
    public class RoverSquadCommander : IRoverSquadCommander
    {
        private IList<IRover> _rovers;
        private IList<String> _roverReports;
        private ILandingSurface _landingSurface;

        public RoverSquadCommander(ILandingSurface landingSurface)
        {
            _rovers = new List<IRover>();
            _roverReports = new List<string>();
            _landingSurface = landingSurface;
        }

        public void DeployNewRover(string deployCommands, string exploreCommands )
        {
            CommandParser commandParser = new CommandParser();
            IRover newRover = new Rover.Rover();
            var newRoverDeployPosition = commandParser.TranslateRoverPosition(deployCommands);
            var newRoverDeployDirection = commandParser.TranslateRoverDirection(deployCommands);
            var newRoverExploreCommands = commandParser.TranslateRoverCommands(exploreCommands);
            _rovers.Add(newRover);
            newRover.Deploy(_landingSurface, newRoverDeployPosition, newRoverDeployDirection);
            newRover.Move(newRoverExploreCommands);
            _roverReports.Add(newRover.Report());
        }

        public IList<string> GetRoverSquadReport()
        {
            return _roverReports;
        }

        public int GetRoverCount()
        {
            return _rovers.Count;
        }

        public ILandingSurface GetLandingSurface()
        {
            return _landingSurface;
        }

        public void SetLandingSurface(ILandingSurface landingSurface)
        {
            _landingSurface = landingSurface;
        }
    }
}
