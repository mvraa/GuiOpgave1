using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace GuiEksamen.Models
{
    [Serializable]
    public class User : BindableBase
    {
        private string name;
        private int freq;
        private int duration;
        private DateTime time;

        public User(string name, int freq, int duration, DateTime time)
        {
            this.name = name;
            this.freq = freq;
            this.time = time;
            this.duration = duration;
        }

        public User() {}

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public int F
        {
            get => freq;
            set => SetProperty(ref freq, value);
        }

        public int Duration
        {
            get => duration;
            set => SetProperty(ref duration, value);
        }

        public DateTime Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }
    }


}
