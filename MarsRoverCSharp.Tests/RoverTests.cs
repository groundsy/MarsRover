using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using MarsRoverCSharp.Core.LandingSurface;
using MarsRoverCSharp.Core.Rover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Tests
{
    /// <summary>
    /// Summary description for RoverTests
    /// </summary>
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void Deploy_Rover_To_Plateau()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5,5));
            Point testPoint = new Point(0,0);

            rover.Deploy(plateau, testPoint, Direction.North );

            Assert.AreEqual(testPoint, rover.Position);
            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        [ExpectedException(typeof(RoverDeployException))]
        public void Deploy_Rover_To_Invalid_Plateau_Point()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point testPoint = new Point(6, 6);

            rover.Deploy(plateau, testPoint, Direction.North);

            Assert.AreNotEqual(testPoint, rover.Position);
            Assert.AreEqual(false, rover.IsDeployed());
            Assert.Fail();
        }

        [TestMethod]
        public void Move_Rover_Facing_North_Left()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5,5));
            Point testPoint = new Point(0,0);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Left);

            rover.Deploy(plateau, testPoint, Direction.North);
            rover.Move(movements);

            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [TestMethod]
        public void Move_Rover_Facing_West_Left()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point testPoint = new Point(0, 0);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Left);

            rover.Deploy(plateau, testPoint, Direction.West);
            rover.Move(movements);

            Assert.AreEqual(Direction.South, rover.Direction);
        }

        [TestMethod]
        public void Move_Rover_Facing_South_Left()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point testPoint = new Point(0, 0);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Left);

            rover.Deploy(plateau, testPoint, Direction.South);
            rover.Move(movements);

            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [TestMethod]
        public void Move_Rover_Facing_East_Left()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point testPoint = new Point(0, 0);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Left);

            rover.Deploy(plateau, testPoint, Direction.East);
            rover.Move(movements);

            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        public void Move_Rover_Facing_North_Right()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point testPoint = new Point(0, 0);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Right);

            rover.Deploy(plateau, testPoint, Direction.North);
            rover.Move(movements);

            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [TestMethod]
        public void Move_Rover_Facing_East_Right()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point testPoint = new Point(0, 0);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Right);

            rover.Deploy(plateau, testPoint, Direction.East);
            rover.Move(movements);

            Assert.AreEqual(Direction.South, rover.Direction);
        }

        [TestMethod]
        public void Move_Rover_Facing_South_Right()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point testPoint = new Point(0, 0);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Right);

            rover.Deploy(plateau, testPoint, Direction.South);
            rover.Move(movements);

            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [TestMethod]
        public void Move_Rover_Facing_West_Right()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point testPoint = new Point(0, 0);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Right);

            rover.Deploy(plateau, testPoint, Direction.West);
            rover.Move(movements);

            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        [ExpectedException(typeof(RoverMoveException))]
        public void Move_Rover_Facing_North_Forward_To_Invalid_Plateau_Point()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point originalPoint = new Point(5, 5);
            Point invalidPoint = new Point(6,6);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Forward);

            rover.Deploy(plateau, originalPoint, Direction.North);
            rover.Move(movements);

            Assert.AreNotEqual(invalidPoint.Y, rover.Position.Y);
            Assert.AreEqual(originalPoint.Y, rover.Position.Y);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(RoverMoveException))]
        public void Move_Rover_Facing_East_Forward_To_Invalid_Plateau_Point()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point originalPoint = new Point(5, 5);
            Point invalidPoint = new Point(6, 6);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Forward);

            // Act
            rover.Deploy(plateau, originalPoint, Direction.East);
            rover.Move(movements);

            // Assert
            Assert.AreNotEqual(invalidPoint.X, rover.Position.X);
            Assert.AreEqual(originalPoint.X, rover.Position.X);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(RoverMoveException))]
        public void Move_Rover_Facing_South_Forward_To_Invalid_Plateau_Point()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point originalPoint = new Point(0, 0);
            Point invalidPoint = new Point(0, -1);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Forward);

            rover.Deploy(plateau, originalPoint, Direction.South);
            rover.Move(movements);

            Assert.AreNotEqual(invalidPoint.Y, rover.Position.Y);
            Assert.AreEqual(originalPoint.Y, rover.Position.Y);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(RoverMoveException))]
        public void Move_Rover_Facing_West_Forward_To_Invalid_Plateau_Point()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5, 5));
            Point originalPoint = new Point(0, 0);
            Point invalidPoint = new Point(-1, 0);
            IList<Movement> movements = new List<Movement>();

            movements.Add(Movement.Forward);

            rover.Deploy(plateau, originalPoint, Direction.West);
            rover.Move(movements);

            Assert.AreNotEqual(invalidPoint.X, rover.Position.X);
            Assert.AreEqual(originalPoint.X, rover.Position.X);
            Assert.Fail();
        }

        [TestMethod]
        public void Rover_Report()
        {
            Rover rover = new Rover();
            ILandingSurface plateau = new Plateau(new Size(5,5));
            var expectedReport = "5 5 N";

            rover.Deploy(plateau, new Point(5,5), Direction.North );
            var report = rover.Report();

            Assert.AreEqual(expectedReport, report);
        }
    }
}
