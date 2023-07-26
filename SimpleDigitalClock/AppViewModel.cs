using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SimpleDigitalClock
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private DateTime _currentDateTime;

        public AppViewModel()
        {
            _currentDateTime = DateTime.Now;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public DateTime CurrentDateTime
        {
            get { return _currentDateTime; }
            private set
            {
                _currentDateTime = value;
                OnPropertyChanged();
            }
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            CurrentDateTime = DateTime.Now;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
