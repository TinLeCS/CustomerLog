using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLog.Models
{
    public abstract class Log : INotifyPropertyChanged
    {
        private string _contactName;
        private DateTime _receivedTime;
        private bool _isResponded;

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string ContactName {
            get { return _contactName; }
            set
            {
                _contactName = value;
                OnPropertyChange();
            }
        }
        public DateTime ReceivedTime {
            get { return _receivedTime; }
            set
            {
                _receivedTime = value;
                OnPropertyChange();
            }
        }
        public bool IsResponded{
            get { return _isResponded; }
            set
            {
                _isResponded = value;
                OnPropertyChange();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        public virtual Customer Customer { get; set; }
    }
}
