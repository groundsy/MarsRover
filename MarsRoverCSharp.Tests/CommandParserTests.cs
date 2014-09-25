using System;
using System.Linq;
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
    /// Summary description for CommandParserTests
    /// </summary>
    [TestClass]
    public class CommandParserTests
    {
        [TestMethod]
        public void Given_A_CommandString_With_One_LandingSurface_Size_Create_Parse_CommandString()
        {
            CommandParser commandParser = new CommandParser();
            Size expectedSizeAfterParse = new Size(5, 5);

            string landingSurfaceCommandString = "5 5";
            Size testSize = commandParser.TranslateLandingSurfaceCoordinates(landingSurfaceCommandString);

            Assert.AreEqual(expectedSizeAfterParse, testSize);
        }

        [TestMethod]
        [ExpectedException(typeof(CommandParserInvalidCommand))]
        public void Given_A_CommandString_With_Invalid_LandingSurface_Size_Create_Parse_CommandString()
        {
            CommandParser commandParser = new CommandParser();
            Size expectedSizeAfterParse = new Size(0, 0);

            string landingSurfaceCommandString = "55";
            Size testSize = commandParser.TranslateLandingSurfaceCoordinates(landingSurfaceCommandString);

            Assert.AreEqual(expectedSizeAfterParse, testSize);
            Assert.Fail();
        }

        [TestMethod]
        public void Given_A_CommandString_With_Rover_Position_And_Direction_Parse_And_Get_Position()
        {
            CommandParser commandParser = new CommandParser();
            Point expectedPointAfterParse = new Point(1, 2);

            string roverPositionAndDirectionCommandString = "1 2 N";
            Point roverPosition = commandParser.TranslateRoverPosition(roverPositionAndDirectionCommandString);

            Assert.AreEqual(expectedPointAfterParse, roverPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(CommandParserInvalidCommand))]
        public void Given_A_CommandString_With_Invalid_Rover_Position_And_Direction()
        {
            CommandParser commandParser = new CommandParser();
            Point expectedPointAfterParse = new Point(0, 0);

            string roverPositionAndDirectionCommandString = "12N";
            Point roverPosition = commandParser.TranslateRoverPosition(roverPositionAndDirectionCommandString);

            Assert.AreEqual(expectedPointAfterParse, roverPosition);
            Assert.Fail();
        }

        [TestMethod]
        public void Given_A_CommandString_With_Rover_Position_And_Direction_Parse_And_Get_Direction()
        {
            CommandParser commandParser = new CommandParser();
            Direction expectedDirectionAfterParse = Direction.North;

            string roverPositionAndDirectionCommandString = "1 2 N";
            Direction roverDirection = commandParser.TranslateRoverDirection(roverPositionAndDirectionCommandString);

            Assert.AreEqual(expectedDirectionAfterParse, roverDirection);
        }

        [TestMethod]
        [ExpectedException(typeof(CommandParserInvalidCommand))]
        public void Given_A_CommandString_With_Rover_Position_And_Direction_Give_Invalid_Direction()
        {
            CommandParser commandParser = new CommandParser();
            Direction expectedDirectionAfterParse = Direction.None;

            string roverPositionAndDirectionCommandString = "1 2 P";
            Direction roverDirection = commandParser.TranslateRoverDirection(roverPositionAndDirectionCommandString);

            Assert.AreEqual(expectedDirectionAfterParse, roverDirection);
            Assert.Fail();
        }


        [TestMethod]
        public void Given_A_CommandString_With_Rover_MovementCommands_Parse_And_Get_Movements()
        {
            CommandParser commandParser = new CommandParser();
            IList<Movement> expectedMovementsAfterParse = new List<Movement>(){Movement.Left, Movement.Right, Movement.Forward};

            string roverMovementCommandString = "LRM";
            IList<Movement> roverMovements = commandParser.TranslateRoverCommands(roverMovementCommandString);

            Assert.AreEqual(expectedMovementsAfterParse.Count, roverMovements.Count);
            Assert.IsTrue(roverMovements.SequenceEqual(expectedMovementsAfterParse));
        }

        [TestMethod]
        [ExpectedException(typeof(CommandParserInvalidCommand))]
        public void Given_A_CommandString_With_Invalid_Rover_MovementCommands()
        {
            CommandParser commandParser = new CommandParser();
            IList<Movement> expectedMovementsAfterParse = new List<Movement>(){Movement.Left, Movement.Forward, Movement.Right};

            string roverMovementCommandString = "BFLQIAYMR";
            IList<Movement> roverMovements = commandParser.TranslateRoverCommands(roverMovementCommandString);

            Assert.AreEqual(expectedMovementsAfterParse.Count, roverMovements.Count);
            Assert.AreNotEqual(roverMovementCommandString.Length, roverMovements.Count);
            Assert.IsTrue(roverMovements.SequenceEqual(expectedMovementsAfterParse));
            Assert.Fail();
        }
    }
}
