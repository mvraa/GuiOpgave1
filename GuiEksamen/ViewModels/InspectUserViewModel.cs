using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GuiEksamen.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace GuiEksamen.ViewModels
{
    public class InspectUserViewModel : BindableBase
    {
        private System.Timers.Timer _interval;
        private System.Timers.Timer _timer;
        private System.Timers.Timer _timeAmount;

        public InspectUserViewModel(User user)
        {
            InspectedUser = user;

            // add current date if it doent exist

            DateTime current = DateTime.Now;
            current = new DateTime(current.Year, current.Month, current.Day);

            var times = InspectedUser.UserTimes.Where(d => d.Timestamp == current);

            if(times.Count() == 0)
            {
                InspectedUser.UserTimes.Add(new UserTimes(current, 0));
            }

            // interval
            _interval = new System.Timers.Timer();
            _interval.Interval = InspectedUser.Freq * 1000;
            _interval.Elapsed += OnIntervalEvent;
            _interval.Enabled = true;
            _interval.Stop();

            // timer
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += OnTimerEvent;
            _timer.Enabled = true;
            _timer.Stop();

            // time amount
            _timeAmount = new System.Timers.Timer();
            _timeAmount.Interval = 2000;
            _timeAmount.Elapsed += OnTimeAmountEvent;
            _timeAmount.Enabled = true;
            _timeAmount.Stop();
        }

        private User inspectedUser;

        public User InspectedUser
        {
            get => inspectedUser;
            set => SetProperty(ref inspectedUser, value);
        }


        public string Greetings
        {
            get { return "Hello " + InspectedUser.Name; }
        }

        string breathMsg = "Press start to begin";
        public string BreathMsg
        {
            get { return breathMsg; }
            set
            {
                SetProperty(ref breathMsg, value);
            }
        }

        int timer = -1;
        public int Timer
        {
            get { return timer; }
            set
            {
                SetProperty(ref timer, value);
            }
        }

        ////////////////////////////////timers////////////////////////////
        private void OnIntervalEvent(Object obj, System.Timers.ElapsedEventArgs e)
        {
            if(BreathMsg == "Breath In")
            {
                BreathMsg = "Breath Out";
            }
            else
            {
                BreathMsg = "Breath In";
            }
        }

        private void OnTimerEvent(Object obj, System.Timers.ElapsedEventArgs e)
        {
            if(timer == -1)
            {
                Timer = InspectedUser.Duration * 60;
                return;
            }

            Timer--;
        }

        private void OnTimeAmountEvent(Object obj, System.Timers.ElapsedEventArgs e)
        {
            DateTime current = DateTime.Now;
            current = new DateTime(current.Year, current.Month, current.Day);

            var times = InspectedUser.UserTimes.Where(d => d.Timestamp == current);

            foreach(UserTimes t in times)
            {
                t.Amount++;
            }
        }

        ////////////////////////////////commands////////////////////////////

        public ICommand _StartCommand;

        public ICommand StartCommand
        {
            get
            {
                return _StartCommand ?? (_StartCommand = new DelegateCommand(() =>
                {
                    OnIntervalEvent(null, null);
                    _timer.Start();
                    _interval.Start();
                    _timeAmount.Start();
                }));
            }
        }

        public ICommand _PauseCommand;

        public ICommand PauseCommand
        {
            get
            {
                return _PauseCommand ?? (_PauseCommand = new DelegateCommand(() =>
                {
                    _timer.Stop();
                    _interval.Stop();
                    _timeAmount.Stop();
                }));
            }
        }

        public ICommand _CloseCommand;

        public ICommand CloseCommand
        {
            get
            {
                return _CloseCommand ??
                       (_CloseCommand = new DelegateCommand(
                           CloseCommand_Execute, CloseCommand_CanExecute));
            }
        }

        private void CloseCommand_Execute()
        {
            // Nothing needs to be done here.
        }

        private bool CloseCommand_CanExecute()
        {
            // Add validity check here if needed.
            return true;
        }
    }
}
