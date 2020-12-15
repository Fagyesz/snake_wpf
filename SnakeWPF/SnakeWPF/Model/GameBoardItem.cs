using SnakeWPF.Common;

namespace SnakeWPF.Model
{
    /// <summary>
    /// The GameBoardItem class represents a single item on the game board.
    /// It is an abstract class.
    /// </summary>
    public abstract class GameBoardItem : NotificationBase
    {
        #region Fields

        protected double _gameBoardWidthPixels;
        protected double _gameBoardHeightPixels;
        protected double _xPosition;
        protected double _yPosition;
        protected double _width;
        protected double _height;
        
        #endregion

        #region Constructors

        
        public GameBoardItem()
        {
        }

        
        public GameBoardItem(double gameBoardWidthPixels, double gameBoardHeightPixels)
        {
            _gameBoardWidthPixels = gameBoardWidthPixels;
            _gameBoardHeightPixels = gameBoardHeightPixels;
        }

        #endregion
        
        #region Events
        #endregion

        #region Properties

        
        public double GameBoardWidthPixels
        {
            get
            {
                return _gameBoardWidthPixels;
            }
            set
            {
                _gameBoardWidthPixels = value;
                RaisePropertyChanged("GameBoardWidthPixels");
                RaisePropertyChanged("Width");
                RaisePropertyChanged("XPosition");
                RaisePropertyChanged("XPositionPixels");
                RaisePropertyChanged("XPositionPixelsScreen");
            }
        }

        
        public double GameBoardHeightPixels
        {
            get
            {
                return _gameBoardHeightPixels;
            }
            set
            {
                _gameBoardHeightPixels = value;
                RaisePropertyChanged("GameBoardHeightPixels");
                RaisePropertyChanged("Height");
                RaisePropertyChanged("YPosition");
                RaisePropertyChanged("YPositionPixels");
                RaisePropertyChanged("YPositionPixelsScreen");
            }
        }

        
        public double XPosition
        {
            get
            {
                return _xPosition;
            }
        }

        
        public double YPosition
        {
            get
            {
                return _yPosition;
            }
        }

        
        public double XPositionPixels
        {
            get
            {
                return (_xPosition / Constants.GameBoardWidthScale) * _gameBoardWidthPixels;
            }
        }

        
        public double YPositionPixels
        {
            get
            {
                return (_yPosition / Constants.GameBoardHeightScale) * _gameBoardHeightPixels;
            }
        }

        
        public double XPositionPixelsScreen
        {
            get
            {
                return ((_xPosition - (_width / 2.0)) / Constants.GameBoardWidthScale) * _gameBoardWidthPixels;
            }
        }

        
        public double YPositionPixelsScreen
        {
            get
            {
                return ((_yPosition - (_height / 2.0)) / Constants.GameBoardHeightScale) * _gameBoardHeightPixels;
            }
        }

        
        public double Width
        {
            get
            {
                return _width;
            }
        }

        
        public double Height
        {
            get
            {
                return _height;
            }
        }

        
        public double WidthPixels
        {
            get
            {
                return (_width / Constants.GameBoardWidthScale) * _gameBoardWidthPixels;
            }
        }

        
        public double HeightPixels
        {
            get
            {
                return (_height / Constants.GameBoardHeightScale) * _gameBoardHeightPixels;
            }
        }

        #endregion

        #region Methods
        #endregion
    }
}
