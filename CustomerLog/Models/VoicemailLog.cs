using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLog.Models
{
    public class VoicemailLog : Log 
    {
        private string _phoneNumber;
        private string _messageSummary;
        public string PhoneNumber {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChange();
            }
        }
        public string MessageSummary {
            get { return _messageSummary; }
            set
            {
                _messageSummary = value;
                OnPropertyChange();
            }
        }
    }
}
