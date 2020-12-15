using System;

namespace SnakeWPF.Model
{
    
    public class Cherry : GameBoardItem
    {
        #region Fields

        private Random _randomNumber;

        // Constants.
        

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public Cherry(double gameBoardWidthPixels, double gameBoardHeightPixels, double snakeXPosition, double snakeYPosition)
            : base(gameBoardWidthPixels, gameBoardHeightPixels)
        {
            _randomNumber = new Random((int)DateTime.Now.Ticks);
            _xPosition = _randomNumber.Next(Constants.MinimumPosition, Constants.MaximumPosition);
            _yPosition = _randomNumber.Next(Constants.MinimumPosition, Constants.MaximumPosition);
            _width = Constants.CherryWidth;
            _height = Constants.CherryHeight;
        }

        #endregion
        
        #region Events
        #endregion

        #region Properties
        #endregion

        #region Methods

        
        public void MoveCherry(Snake theSnake)
        {
            bool cherryMoved = false;
            double xDiff;
            double yDiff;

            while (!cherryMoved)
            {
                
                _xPosition = _randomNumber.Next(Constants.MinimumPosition, Constants.MaximumPosition);
                _yPosition = _randomNumber.Next(Constants.MinimumPosition, Constants.MaximumPosition);
                
                xDiff = Math.Abs(_xPosition - theSnake.TheSnakeHead.XPosition);
                yDiff = Math.Abs(_yPosition - theSnake.TheSnakeHead.YPosition);
                if (xDiff > Constants.PlacementBuffer * _width || yDiff > Constants.PlacementBuffer * _height)
                {
                    
                    foreach (SnakeBodyPart bodyPart in theSnake.TheSnakeBody)
                    {
                        xDiff = Math.Abs(_xPosition - bodyPart.XPosition);
                        yDiff = Math.Abs(_yPosition - bodyPart.YPosition);
                        if (xDiff > Constants.PlacementBuffer * _width || yDiff > Constants.PlacementBuffer * _height)
                        {
                            cherryMoved = true;
                        }
                        else
                        {
                            cherryMoved = false;
                            break;
                        }
                    }
                }
            }

            
            RaisePropertyChanged("XPosition");
            RaisePropertyChanged("XPositionPixels");
            RaisePropertyChanged("XPositionPixelsScreen");
            RaisePropertyChanged("YPosition");
            RaisePropertyChanged("YPositionPixels");
            RaisePropertyChanged("YPositionPixelsScreen");
        }

        #endregion
    }
}
