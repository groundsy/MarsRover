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
    /// Summary description for CommanderTests
    /// </summary>
    [TestClass]
    public class LandingSurfaceCommandTests
    {
        [TestMethod]
        public void Build_Landing_Surface_With_Size()
        {
            Size expectedSize = new Size(5,5);
            LandingSurfaceCommander plateauCommand = new LandingSurfaceCommander(expectedSize);

            Assert.AreEqual(expectedSize, plateauCommand.GetLandingSurfaceSize());
        }

        [TestMethod]
        public void Build_Landing_Surface_With_Size_From_String()
        { 
            Size expectedSize = new Size(5, 5);
            string landingSurfaceCommandString = "5 5";
            LandingSurfaceCommander plateauCommand = new LandingSurfaceCommander(landingSurfaceCommandString);
            
           
            Assert.AreEqual(expectedSize, plateauCommand.GetLandingSurfaceSize());
        }

        [TestMethod]
        public void Build_Landing_Surface_Then_Set_Size_With_Size_Parameter()
        {
            Size expectedSize = new Size(5, 5);
            string landingSurfaceCommandString = "5 5";
            LandingSurfaceCommander plateauCommand = new LandingSurfaceCommander();

            plateauCommand.SetLandingSurfaceSize(expectedSize);

            Assert.AreEqual(expectedSize, plateauCommand.GetLandingSurfaceSize());
        }

        [TestMethod]
        public void Build_Landing_Surface_Then_Set_Size_With_String_Parameter()
        {
            Size expectedSize = new Size(5, 5);
            string landingSurfaceCommandString = "5 5";
            LandingSurfaceCommander plateauCommand = new LandingSurfaceCommander();

           plateauCommand.SetLandingSurfaceSize(landingSurfaceCommandString);

            Assert.AreEqual(expectedSize, plateauCommand.GetLandingSurfaceSize());
        }
    }
}
