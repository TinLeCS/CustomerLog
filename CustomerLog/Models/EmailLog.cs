using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLog.Models
{
    public class EmailLog : Log
    {
        private string _email;
        private string _subject;
        private string _text;

        public string Email {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChange();
            }
        }
        public string Subject {
            get { return _subject; }
            set
            {
                _subject = value;
                OnPropertyChange();
            }
        }
        public string Text {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChange();
            }
        }
    }
}
