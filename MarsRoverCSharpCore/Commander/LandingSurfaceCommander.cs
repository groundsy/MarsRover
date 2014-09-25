using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using MarsRoverCSharp.Core.LandingSurface;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core.Commander
{
    public class LandingSurfaceCommander : ILandingSurfaceCommander
    {
        private ILandingSurface _landingSurface;
        public Size LandingSize { get; set; }

        public LandingSurfaceCommander()
        {
            _landingSurface = new Plateau();

        }
        
        public LandingSurfaceCommander(Size size)
        {
            _landingSurface = new Plateau(size);

        }

        public LandingSurfaceCommander(string size)
        {
            CommandParser commandParser = new CommandParser();
            var plateauSize = commandParser.TranslateLandingSurfaceCoordinates(size);
            _landingSurface = new Plateau(plateauSize);
        }

        public ILandingSurface GetLandingSurface()
        {
            return _landingSurface;
        }

        public Size GetLandingSurfaceSize()
        {
            return _landingSurface.GetSize();
        }

        public void SetLandingSurfaceSize(Size size)
        {
            _landingSurface.SetSize(size);
        }

        public void SetLandingSurfaceSize(string size)
        {
            CommandParser commandParser = new CommandParser();
            var plateauSize = commandParser.TranslateLandingSurfaceCoordinates(size);
            _landingSurface.SetSize(plateauSize);
        }
    }
}
