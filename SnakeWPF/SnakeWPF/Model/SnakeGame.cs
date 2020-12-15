using SnakeWPF.Common;
using System;
using System.Windows.Threading;

namespace SnakeWPF.Model
{
    
    public class SnakeGame : NotificationBase
    {
        #region Fields

        private double _gameBoardWidthPixels;
        private double _gameBoardHeightPixels;
        private DispatcherTimer _gameTimer;
        private int _gameStepMilliSeconds;
        private int _gameLevel;
        private DispatcherTimer _restartTimer;
        
        #endregion

        #region Constructors

        
        public SnakeGame()
        {
            
            _gameBoardWidthPixels = Constants.DefaultGameBoardWidthPixels;
            _gameBoardHeightPixels = Constants.DefaultGameBoardHeightPixels;

            
            Snake.OnHitBoundary += new HitBoundary(HitBoundaryEventHandler);
            Snake.OnHitSnake += new HitSnake(HitSnakeEventHandler);
            Snake.OnEatCherry += new EatCherry(EatCherryEventHandler);

            
            StartNewGame();
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        
        public double GameBoardWidthPixels
        {
            get
            {
                return (int)_gameBoardWidthPixels;
            }
            set
            {
                _gameBoardWidthPixels = value;
                RaisePropertyChanged("GameBoardWidthPixels");

                TheSnake.GameBoardWidthPixels = value;
            }
        }

        
        public double GameBoardHeightPixels
        {
            get
            {
                return (int)_gameBoardHeightPixels;
            }
            set
            {
                _gameBoardHeightPixels = value;
                RaisePropertyChanged("GameBoardHeightPixels");

                TheSnake.GameBoardHeightPixels = value;
            }
        }

        
        public Snake TheSnake { get; private set; }

        
        public Cherry TheCherry { get; private set; }

        
        public string TitleText
        {
            get
            {
                return "Snake " + _gameLevel + "/" + Constants.EndLevel;
            }
        }

        
        public bool IsGameOver { get; private set; }

        
        public bool IsGameRunning
        {
            get
            {
                return !IsGameOver;
            }
        }

        
        public int RestartCountdownSeconds { get; private set; }

        #endregion

        #region Methods

        
        private void StartNewGame()
        {
            
            TheSnake = new Snake(_gameBoardWidthPixels, _gameBoardHeightPixels);
            RaisePropertyChanged("TheSnake");
            TheCherry = new Cherry(_gameBoardWidthPixels, _gameBoardHeightPixels, TheSnake.TheSnakeHead.XPosition, TheSnake.TheSnakeHead.YPosition);
            RaisePropertyChanged("TheCherry");

            
            IsGameOver = false;
            RaisePropertyChanged("IsGameOver");
            RaisePropertyChanged("IsGameRunning");

            
            RestartCountdownSeconds = Constants.RestartCountdownStartSeconds;
            RaisePropertyChanged("RestartCountdownSeconds");

           
            _gameLevel = Constants.StartLevel;
            RaisePropertyChanged("TitleText");
            _gameStepMilliSeconds = Constants.DefaultGameStepMilliSeconds;
            _gameTimer = new DispatcherTimer();
            _gameTimer.Interval = TimeSpan.FromMilliseconds(_gameStepMilliSeconds);
            _gameTimer.Tick += new EventHandler(GameTimerEventHandler);
            _gameTimer.Start();
        }

        
        private void RestartGame()
        {
            
            RestartCountdownSeconds = Constants.RestartCountdownStartSeconds;
            RaisePropertyChanged("RestartCountdownSeconds");
            _restartTimer = new DispatcherTimer();
            _restartTimer.Interval = TimeSpan.FromMilliseconds(Constants.RestartStepMilliSeconds);
            _restartTimer.Tick += new EventHandler(RestartTimerEventHandler);
            _restartTimer.Start();
        }

        
        private void HitBoundaryEventHandler()
        {
            IsGameOver = true;
            RaisePropertyChanged("IsGameOver");
            RaisePropertyChanged("IsGameRunning");
        }

       
        private void HitSnakeEventHandler()
        {
            IsGameOver = true;
            RaisePropertyChanged("IsGameOver");
            RaisePropertyChanged("IsGameRunning");
        }

        
        private void EatCherryEventHandler()
        {
            
            TheCherry.MoveCherry(TheSnake);

           
            _gameLevel++;
            RaisePropertyChanged("TitleText");
            if (_gameLevel < Constants.EndLevel)
            {
                _gameStepMilliSeconds = _gameStepMilliSeconds - Constants.DecreaseGameStepMilliSeconds;
                _gameTimer.Interval = TimeSpan.FromMilliseconds(_gameStepMilliSeconds);
            }
            else
            {
                
                IsGameOver = true;
                RaisePropertyChanged("IsGameOver");
                RaisePropertyChanged("IsGameRunning");
            }
        }

        
        private void GameTimerEventHandler(object sender, EventArgs e)
        {
            if (IsGameOver)
            {
                
                if (_gameTimer.IsEnabled)
                {
                    _gameTimer.Stop();  
                    RestartGame();      
                }
            }
            else
            {
               
                TheSnake.UpdateSnakeStatus(TheCherry);
            }
        }

       
        private void RestartTimerEventHandler(object sender, EventArgs e)
        {
            RestartCountdownSeconds--;
            RaisePropertyChanged("RestartCountdownSeconds");

            if (RestartCountdownSeconds == 0)
            {
                _restartTimer.Stop();  
                StartNewGame();        
            }
        }

       
        public void ProcessKeyboardEvent(Direction direction)
        {
            TheSnake.SetSnakeDirection(direction);
        }

        #endregion
    }
}
