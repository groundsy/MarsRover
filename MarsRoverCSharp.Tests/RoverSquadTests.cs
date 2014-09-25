using System;
using System.Text;
using System.Collections.Generic;
using MarsRoverCSharp.Core.Commander;
using MarsRoverCSharp.Core.LandingSurface;
using MarsRoverCSharp.Core.Rover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Tests
{
    /// <summary>
    /// Summary description for RoverSquadTests
    /// </summary>
    [TestClass]
    public class RoverSquadTests
    {
        [TestMethod]
        public void Initialize_RoverSquad_With_Landing_Surface_And_Assure_Same_LandingSurface_Is_Returned()
        {
            ILandingSurface expectedLandingSurface = new Plateau(new Size(5,5));
            RoverSquadCommander roverSquad = new RoverSquadCommander(expectedLandingSurface);

            Assert.AreSame(expectedLandingSurface, roverSquad.GetLandingSurface());
        }

        [TestMethod]
        public void Deploy_New_Rover_To_RoverSquad_With_Deploy_And_Explore_Commands_As_String()
        {
            var plateauSizeCommand = "5 5";
            var roverDeployCommands = "1 2 N";
            var roverExploreCommands = "LMLMLMLMM";
            var expectedRoverReport = "1 3 N";
            LandingSurfaceCommander plateauCommander = new LandingSurfaceCommander(plateauSizeCommand);
            RoverSquadCommander roverSquad = new RoverSquadCommander(plateauCommander.GetLandingSurface());

            roverSquad.DeployNewRover(roverDeployCommands, roverExploreCommands);
            var roverReport = roverSquad.GetRoverSquadReport();

            Assert.AreEqual(expectedRoverReport,roverReport[0]);
        }

        [TestMethod]
        public void Deploy_Two_Rovers_To_RoverSquad_With_Deploy_And_Explore_Commands_As_String()
        {
            var plateauSizeCommand = "5 5";
            var roverOneDeployCommands = "1 2 N";
            var roverOneExploreCommands = "LMLMLMLMM";
            var expectedRoverOneReport = "1 3 N";
            var roverTwoDeployCommands = "3 3 E";
            var roverTwoExploreCommands = "MMRMMRMRRM";
            var expectedRoverTwoReport = "5 1 E";
            LandingSurfaceCommander plateauCommander = new LandingSurfaceCommander(plateauSizeCommand);
            RoverSquadCommander roverSquad = new RoverSquadCommander(plateauCommander.GetLandingSurface());

            roverSquad.DeployNewRover(roverOneDeployCommands, roverOneExploreCommands);
            roverSquad.DeployNewRover(roverTwoDeployCommands, roverTwoExploreCommands);
            var roverReports = roverSquad.GetRoverSquadReport();

            Assert.AreEqual(expectedRoverOneReport, roverReports[0]);
            Assert.AreEqual(expectedRoverTwoReport, roverReports[1]);
        }
    }
}
