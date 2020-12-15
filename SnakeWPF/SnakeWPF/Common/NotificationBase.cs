using System.ComponentModel;

namespace SnakeWPF.Common
{
    
    public class NotificationBase : INotifyPropertyChanged
    {
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties
        #endregion

        #region Methods

        
        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}
