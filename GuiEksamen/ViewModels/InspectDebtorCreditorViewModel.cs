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
    public class InspectDebtorCreditorViewModel : BindableBase
    {
        
        public InspectDebtorCreditorViewModel(User debtorToInspect)
        {
            InspectedDebtor = debtorToInspect;
        }

        private User inspectedDebtor;

        public User InspectedDebtor
        {
            get => inspectedDebtor;
            set => SetProperty(ref inspectedDebtor, value);
        }


        double val;
        public double Value
        {
            get => val;
            set => SetProperty(ref val, value);
        }

        string desc = "";
        public string Desc
        {
            get => desc;
            set => SetProperty(ref desc, value);
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
