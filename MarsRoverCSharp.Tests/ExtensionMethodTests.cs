using System;
using System.Text;
using System.Collections.Generic;
using MarsRoverCSharp.Core;
using MarsRoverCSharp.Core.Rover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Tests
{
    /// <summary>
    /// Summary description for ExtensionMethodTests
    /// </summary>
    [TestClass]
    public class ExtensionMethodTests
    {
        [TestMethod]
        public void Direction_North_To_Report_String()
        {
            string expectedString = "N";
            Direction direction = Direction.North;
            
            // Act 
            string strDirection = direction.ToReportString();

            // Assert
            Assert.AreEqual(expectedString, strDirection);
        }
    }
}
