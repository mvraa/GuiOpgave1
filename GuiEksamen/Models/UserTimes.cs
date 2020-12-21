using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace GuiEksamen.Models
{
    public class UserTimes : BindableBase
    {
        private int amount;
        private DateTime timestamp;

        public UserTimes(DateTime timestamp, int amount)
        {
            this.timestamp = new DateTime(timestamp.Year, timestamp.Month, timestamp.Day);

            this.amount = amount;
        }

        public UserTimes()
        {
        }

        public int Amount
        {
            get => amount;
            set => SetProperty(ref this.amount, value);
        }

        public DateTime Timestamp
        {
            get => timestamp;
            set => SetProperty(ref this.timestamp, value);
        }
    }
}
