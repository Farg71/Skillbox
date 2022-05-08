using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.BotClass
{
    struct MessageLog
    {
        public string Time { get; set; }

        public long MessageId { get; set; }

        public string Message { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public MessageLog(string Time, long Id, string Message, string FirstName, string LastName)
        {
            this.Time = Time;
            this.MessageId = Id;
            this.Message = Message;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}
