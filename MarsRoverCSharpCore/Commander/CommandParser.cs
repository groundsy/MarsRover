using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsRoverCSharp.Core.LandingSurface;
using MarsRoverCSharp.Core.Rover;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core.Commander
{
    public class CommandParser
    {
         private const char CommandSeperator = ' ';
         private const int XCoordinateIndex = 0, YCoordinateIndex = 1, NumLandingSurfaceCommandValues = 2, FacingDirectionIndex = 2, NumRoverPositionCommandValues = 3;

         private readonly IDictionary<char, Direction> _directionDictionary;
         private readonly IDictionary<char, Movement> _movementDictionary;

        public CommandParser()
        {
            // Valid directions.
            _directionDictionary = new Dictionary<char, Direction>
            {
                 {'N', Direction.North},
                 {'S', Direction.South},
                 {'E', Direction.East},
                 {'W', Direction.West}
            };

            // Valid movements.
            _movementDictionary = new Dictionary<char, Movement>
            {
                 {'L', Movement.Left},
                 {'R', Movement.Right},
                 {'M', Movement.Forward}
            };   
        }

        public Size TranslateLandingSurfaceCoordinates(string landingSurfaceCoordinates)
        {
            // Commands are separated by spaces. 
            string[] coordinateCommand = landingSurfaceCoordinates.Split(CommandSeperator);

            // If invalid number of landing surface commands, throw exception.
            if (coordinateCommand.Length != NumLandingSurfaceCommandValues)
            {
                ThrowInvalidLandingSurfaceSizeCommandException(coordinateCommand.ToString());
            }        
            // If valid number of landing surface commands, build the size out of the given commands.
            else
            {
                int width = Convert.ToInt32(coordinateCommand[XCoordinateIndex]);
                int height = Convert.ToInt32(coordinateCommand[YCoordinateIndex]);

                return new Size(width, height);
            }

            // If something went wrong, return size of 0,0.
            return new Size(0,0);
        }

      public Point TranslateRoverPosition(string roverPosition)
      {
          // Commands are separated by spaces.
          string[] roverPositionCommand = roverPosition.Split(CommandSeperator);

          // If invalid number of rover position commands, throw exception.
          if (roverPositionCommand.Length != NumRoverPositionCommandValues)
          {
              ThrowInvalidRoverPositionCommandException(roverPosition);
          }
          // If valid number of rover position commands, build the position out of the given commands.
          else
          {
              int xCoordinate = Convert.ToInt32(roverPositionCommand[XCoordinateIndex]);
              int yCoordinate = Convert.ToInt32(roverPositionCommand[YCoordinateIndex]);
          
              return new Point(xCoordinate,yCoordinate);
          }
          // If something went wrong, return position of 0,0.
          return new Point(0,0);
        }

      public Direction TranslateRoverDirection(string roverPosition)
      {
          // Commands are separated by spaces.
          string[] roverPositionCommand = roverPosition.Split(CommandSeperator);

          // If invalid number of rover position commands, throw exception.
          if (roverPositionCommand.Length != NumRoverPositionCommandValues)
          {
              ThrowInvalidRoverPositionCommandException(roverPositionCommand.ToString());
          }
          // If valid number of rover position commands, build the direction out of the given commands.    
          else
          {
              char direction = Convert.ToChar(roverPositionCommand[FacingDirectionIndex].ToUpper());

              // If the given direction is valid, return that direction.
              if (_directionDictionary.ContainsKey(direction))
              {
                  return _directionDictionary[direction];
              }
              // If the given direction is not valid, throw exception.
              else
              {
              ThrowInvalidRoverDirectionCommandException(direction);
              }  
          }
          // If something went wrong, return a direction of none.
          return Direction.None;
      }

        public List<Movement> TranslateRoverCommands(string roverCommands)
        {
            List<Movement> movements = new List<Movement>();

            char[] commands = roverCommands.ToUpper().ToCharArray();

            foreach (char command in commands)
            {
                // If the command is valid, add it to the list of movements.
                if (_movementDictionary.ContainsKey(command))
                {
                    movements.Add(_movementDictionary[command]);
                }
                // If the command is not valid, throw exception.
                else
                {
                   ThrowInvalidRoverMoveCommandException(command); 
                }
            }

            return movements;
        }

        private static void ThrowInvalidLandingSurfaceSizeCommandException(string command)
        {
            var exceptionMessage = String.Format("Translation of landing surface coordinates failed. \n{0} is not a valid command. \nExpected '<integer> <integer>'.",
                command);

            throw new CommandParserInvalidCommand(exceptionMessage);
        }

        private static void ThrowInvalidRoverPositionCommandException(string command)
        {
            var exceptionMessage = String.Format("Translation of rover position failed. \n{0} is not a valid command. \nExpected 'X Y Direction'.",
                command);

            throw new CommandParserInvalidCommand(exceptionMessage);
        }

        private static void ThrowInvalidRoverDirectionCommandException(char direction)
        {
            var exceptionMessage = String.Format("Translation of rover direction failed. \n{0} is not a valid direction. \nExpected 'N, E, S, or W'.",
                direction);

            throw new CommandParserInvalidCommand(exceptionMessage);
        }

        private static void ThrowInvalidRoverMoveCommandException(char command)
        {
            var exceptionMessage = String.Format("Translation of rover command failed. \n{0} is not a valid command. \nExpected 'M, L, or R'.",
                command);

            throw new CommandParserInvalidCommand(exceptionMessage);
        }
    }
}
