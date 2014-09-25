using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverCSharp.Core.LandingSurface;

/*  Eric Grounds
 *  Mars Rover Problem
 */

namespace MarsRoverCSharp.Core.Rover
{
    public class Rover : IRover
    {
        private ILandingSurface _landingSurface;
        private bool _isDeployed;
        private readonly IDictionary<Movement, Action> _roverMovements;
        private readonly IDictionary<Direction, Action> _leftMove;
        private readonly IDictionary<Direction, Action> _rightMove;
        private readonly IDictionary<Direction, Action> _forwardMove;

        public Point Position { get; set; }
        public Direction Direction { get; set; }

        public Rover()
        {
            _roverMovements = new Dictionary<Movement, Action>
            {
                {Movement.Forward, () => _forwardMove[Direction].Invoke()},
                {Movement.Left, () => _leftMove[Direction].Invoke()},
                {Movement.Right, () => _rightMove[Direction].Invoke()}
            };

            _leftMove = new Dictionary<Direction, Action>
            {
                {Direction.North, () => Direction = Direction.West},
                {Direction.West, () => Direction = Direction.South},
                {Direction.South, () => Direction = Direction.East},
                {Direction.East, () => Direction = Direction.North}
            };

            _rightMove = new Dictionary<Direction, Action>
            {
                {Direction.North, () => Direction = Direction.East},
                {Direction.East, () => Direction = Direction.South},
                {Direction.South, () => Direction = Direction.West},
                {Direction.West, () => Direction = Direction.North}
            };

            _forwardMove = new Dictionary<Direction, Action>
            {
                {Direction.North, () =>
                {
                    // Make sure the new position is valid on the landing surface before moving rover.
                    if (_landingSurface.IsValidPoint(new Point(Position.X, Position.Y + 1)))
                    {
                         Position = new Point(Position.X, Position.Y + 1);
                    }  
                    // If the new position is invalid, throw exception.
                    else
                    {
                        ThrowMoveException(_landingSurface, new Point(Position.X, Position.Y + 1));
                    }   
                }},

                {Direction.East, () =>
                {
                    // Make sure the new position is valid on the landing surface before moving rover.
                    if (_landingSurface.IsValidPoint(new Point(Position.X + 1, Position.Y)))
                    {
                        Position = new Point(Position.X + 1, Position.Y);
                    }
                    // If the new position is invalid, throw exception.
                    else
                    {
                       ThrowMoveException(_landingSurface, new Point(Position.X + 1, Position.Y)); 
                    }     
                }},
                {Direction.South, () =>
                {
                    // Make sure the new position is valid on the landing surface before moving rover.
                    if (_landingSurface.IsValidPoint(new Point(Position.X, Position.Y - 1)))
                    {
                        Position = new Point(Position.X, Position.Y - 1);
                    }
                    // If the new position is invalid, throw exception.
                    else
                    {
                        ThrowMoveException(_landingSurface, new Point(Position.X, Position.Y - 1));
                    }
                }},
                {Direction.West, () =>
                {
                    // Make sure the new position is valid on the landing surface before moving rover.
                    if (_landingSurface.IsValidPoint(new Point(Position.X - 1, Position.Y)))
                    {
                        Position = new Point(Position.X - 1, Position.Y);
                    }
                    // If the new position is invalid, throw exception.
                    else
                    {
                       ThrowMoveException(_landingSurface, new Point(Position.X - 1, Position.Y)); 
                    }   
                }},
            };
        }

        public bool IsDeployed()
        {
            return _isDeployed;
        }

        public void Deploy(ILandingSurface landingSurface, Point point, Direction direction)
        {
            // Make sure the rover deploy point is a valid point on the landing surface.
            if (landingSurface.IsValidPoint(point))
            {
                this._landingSurface = landingSurface;
                this.Position = point;
                this.Direction = direction;
                _isDeployed = true;
                return;
            }
            // If the rover deploy point is invalid on the landing surface, throw exception
            ThrowDeployException(landingSurface, point);
        }

        public void Move(IEnumerable<Movement> movements)
        {
            // Make sure rover is deployed before trying to move it.
            if (_isDeployed)
            {
                // Enumerate through the movement list passed in.
                foreach (var movement in movements)
                {
                    // Perform the movement.
                    _roverMovements[movement].Invoke();
                }
            }
        }

        public string Report()
        {
            return String.Format("{0} {1} {2}", Position.X, Position.Y, Direction.ToReportString());
        }

        private static void ThrowDeployException(ILandingSurface landingSurface, Point point)
        {
            var size = landingSurface.GetSize();
            var exceptionMessage = String.Format("Rover deployment failed for point ({0},{1}). Landing surface size is {2}x{3}.",
                point.X, point.Y, size.Width, size.Height);

            throw new RoverDeployException(exceptionMessage);
        }

        private static void ThrowMoveException(ILandingSurface landingSurface, Point newPoint)
        {
            var size = landingSurface.GetSize();
            var exceptionMessage = String.Format("Rover move forward failed for point ({0},{1}). Landing surface size is {2}x{3}.",
                newPoint.X, newPoint.Y, size.Width, size.Height);

            throw new RoverMoveException(exceptionMessage);
        }
    }
}
