using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Mvvm;
using GuiEksamen.Models;
using Prism.Commands;

namespace GuiEksamen.ViewModels
{
    public class AddUserWindowViewModel : BindableBase
    {
        private ObservableCollection<User> _users;

        public AddUserWindowViewModel(ObservableCollection<User> users)
        {
            _users = users;
        }

        #region Properties

        string name = "";
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }

        int freq;
        public int Freq
        {
            get { return freq; }
            set
            {
                SetProperty(ref freq, value);
            }
        }

        int duration;
        public int Duration
        {
            get { return duration; }
            set
            {
                SetProperty(ref duration, value);
            }
        }

        #endregion Properties 


        #region Commands

        public ICommand _AddButtonCommand;

        public ICommand AddButtonCommand
        {
            get
            {
                return _AddButtonCommand ?? (_AddButtonCommand = new DelegateCommand(() =>
                {
                    _users.Add(new User(Name, Freq, Duration, DateTime.Now));
                }));
            }
        }

        #endregion Commands

    }


}
