using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverCSharp.Core.LandingSurface;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Tests
{
    /// <summary>
    /// Summary description for PlateauTests
    /// </summary>
    [TestClass]
    public class PlateauTests
    {
        [TestMethod]
        public void Plateau_Set_Valid_Size()
        {
            Size size = new Size(5,5);
            Plateau plateau = new Plateau();
            
            plateau.SetSize(size);

            Assert.AreEqual(new Size(5, 5), plateau.GetSize());
        }

        [TestMethod]
        [ExpectedException(typeof(LandingSurfaceSizeException))]
        public void Plateau_Set_Invalid_Size_Negative_Width()
        {
            Size size = new Size(-1, 5);
            Plateau plateau = new Plateau();

            plateau.SetSize(size);

            Assert.AreNotEqual(size, plateau.GetSize());
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(LandingSurfaceSizeException))]
        public void Plateau_Set_Invalid_Size_Negative_Height()
        {
            Size size = new Size(0, -8);
            Plateau plateau = new Plateau();

            plateau.SetSize(size);

            Assert.AreNotEqual(size, plateau.GetSize());
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(LandingSurfaceSizeException))]
        public void Plateau_Set_Invalid_Size_Negative_Width_And_Height()
        {
            Size size = new Size(-1, -8);
            Plateau plateau = new Plateau();

            plateau.SetSize(size);

            Assert.AreNotEqual(size, plateau.GetSize());
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(LandingSurfaceSizeException))]
        public void Plateau_Initialize_With_Invalid_Size()
        {
            Size size = new Size(-1, -8);
            Plateau plateau = new Plateau(size);

            Assert.AreNotEqual(size, plateau.GetSize());
            Assert.Fail();
        }

        [TestMethod]
        public void Is_Valid_Point()
        {  
            Point testPoint = new Point(6,6);
            Size size = new Size(5,5);
            Plateau plateau = new Plateau(size);

            bool validPoint =  plateau.IsValidPoint(testPoint);

            Assert.IsFalse(validPoint, "Test point {0},{1} should not be valid on this plateau of {2},{3}", 
                           testPoint.X, testPoint.Y, size.Width, size.Height);
          
        }
    }
}
