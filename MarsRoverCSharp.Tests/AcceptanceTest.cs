using System;
using System.Runtime.InteropServices.ComTypes;
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
    /// Summary description for AcceptanceTests
    /// </summary>
    [TestClass]
    public class AcceptanceTest
    {
        public string BuildCommandString()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            return commandStringBuilder.ToString();
        }

        [TestMethod]
        public void MarsRover_Problem_Statement_Test_Given_The_Criteria()
        {
            // Set-up end result expectations.
            var expectedPlateauSize = new Size(5, 5);
            var expectedRoverOneReportString = "1 3 N";
            var expectedRoverTwoReportString = "5 1 E";
            var expectedDeployedRoverSquadCount = 2;

            // Get the test input given per problem statement
            var testInput = BuildCommandString();

            // split test input based on newlines
            var inputCommands = testInput.Split(new [] {Environment.NewLine}, StringSplitOptions.None);

            // Build landing plateau
            LandingSurfaceCommander plateauCommander = new LandingSurfaceCommander(inputCommands[0]);

            // Create and initialize a new rover squad and give it the landing surface that the rovers will be deployed to.
            RoverSquadCommander roverSquad = new RoverSquadCommander(plateauCommander.GetLandingSurface());

            // Deploy rover one to the squad with the given position and explore commands.
            roverSquad.DeployNewRover(inputCommands[1], inputCommands[2]);

            // Deploy rover two to the squad with the given position and explore commands.
            roverSquad.DeployNewRover(inputCommands[3], inputCommands[4]);

            // Get rover squad reports.
            var squadReports = roverSquad.GetRoverSquadReport();
     
            Assert.AreEqual(expectedPlateauSize, plateauCommander.GetLandingSurfaceSize(),  "The expected plateau size does not match the actual size");
            Assert.AreEqual(expectedDeployedRoverSquadCount, roverSquad.GetRoverCount(),"roverSquad count {0}. expected count {1}", roverSquad.GetRoverCount(), expectedDeployedRoverSquadCount);
            Assert.AreEqual(expectedRoverOneReportString, squadReports[0]);
            Assert.AreEqual(expectedRoverTwoReportString, squadReports[1]);
        }
    }
}
