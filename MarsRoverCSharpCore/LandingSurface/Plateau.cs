using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core.LandingSurface
{
    public class Plateau : ILandingSurface
    {
        private Size _size;

        public Plateau()
        {
            _size = new Size(0,0);
        }

        public Plateau(Size size)
        {
            // Make sure width and height are both positive.
            if (size.Width >= 0 && size.Height >= 0)
            {
                _size = size;
            }
            // If the size is invalid, throw exception.
            else
            {
            ThrowLandingSurfaceSizeException(size);
            }
        }

        public Size GetSize()
        {
           return _size;
        }

        public void SetSize(Size size)
        {
            // Make sure width and height are both positive.
            if (size.Width >= 0 && size.Height >= 0)
            {
                _size = size;
            }
            // If the size is invalid, throw exception.
            else
            {
                ThrowLandingSurfaceSizeException(size);
            }

            
        }

        public bool IsValidPoint(Point point)
        {
            // Check if the given point is valid on the plateau.
            return (point.X >= 0 && point.X <= _size.Width) &&
                   (point.Y >= 0 && point.Y <= _size.Height);
        }

        private static void ThrowLandingSurfaceSizeException(Size size)
        {
            var exceptionMessage = String.Format("Plateau set size of ({0},{1}) failed. Width and Height of plateau must be positive.",
                size.Width, size.Height);

            throw new LandingSurfaceSizeException(exceptionMessage);
        }
    }
}
