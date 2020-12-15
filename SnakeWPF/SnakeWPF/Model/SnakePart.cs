
namespace SnakeWPF.Model
{
    
    public abstract class SnakePart : GameBoardItem
    {
        #region Fields

        protected Direction _directionOfTravel;
        
        #endregion

        #region Constructors

        
        public SnakePart()
        {
        }

        
        public SnakePart(double gameBoardWidthPixels, double gameBoardHeightPixels, Direction direction)
            : base(gameBoardWidthPixels, gameBoardHeightPixels)
        {
            _directionOfTravel = direction;
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        
        public Direction DirectionOfTravel
        {
            get
            {
                return _directionOfTravel;
            }
            set
            {
                _directionOfTravel = value;
                RaisePropertyChanged("DirectionOfTravel");
                RaisePropertyChanged("DirectionOfTravelDegrees");
            }
        }

        
        public double DirectionOfTravelDegrees
        {
            get
            {
                double direction = 0;

                if (_directionOfTravel == Direction.Up)
                {
                    direction = Constants.DirectionUpDegrees;
                }
                else if (_directionOfTravel == Direction.Right)
                {
                    direction = Constants.DirectionRightDegrees;
                }
                else if (_directionOfTravel == Direction.Down)
                {
                    direction = Constants.DirectionDownDegrees;
                }
                else if (_directionOfTravel == Direction.Left)
                {
                    direction = Constants.DirectionLeftDegrees;
                }

                return direction;
            }
        }

        #endregion

        #region Methods

        
        public void UpdatePosition()
        {
            if (_directionOfTravel == Direction.Up)
            {
                _yPosition = _yPosition - Constants.StepSize;
                RaisePropertyChanged("YPosition");
                RaisePropertyChanged("YPositionPixels");
                RaisePropertyChanged("YPositionPixelsScreen");
            }
            else if (_directionOfTravel == Direction.Right)
            {
                _xPosition = _xPosition + Constants.StepSize;
                RaisePropertyChanged("XPosition");
                RaisePropertyChanged("XPositionPixels");
                RaisePropertyChanged("XPositionPixelsScreen");
            }
            else if (_directionOfTravel == Direction.Down)
            {
                _yPosition = _yPosition + Constants.StepSize;
                RaisePropertyChanged("YPosition");
                RaisePropertyChanged("YPositionPixels");
                RaisePropertyChanged("YPositionPixelsScreen");
            }
            else if (_directionOfTravel == Direction.Left)
            {
                _xPosition = _xPosition - Constants.StepSize;
                RaisePropertyChanged("XPosition");
                RaisePropertyChanged("XPositionPixels");
                RaisePropertyChanged("XPositionPixelsScreen");
            }
        }

        #endregion
    }
}
