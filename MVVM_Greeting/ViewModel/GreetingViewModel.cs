using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MVVM_Greeting.Commands;
using MVVM_Greeting.Model;
using System.Collections.ObjectModel;

namespace MVVM_Greeting.ViewModel
{
    public class GreetingViewModel : INotifyPropertyChanged
    {

        private ICommand _MyCommand;

        public ICommand MyCommand
        {
            get
            {
                if (_MyCommand == null)
                {
                    _MyCommand = new RelayCommand(SayGreeting,CanExecute);
                }
                return _MyCommand;
            }
        }


        public GreetingViewModel()
        {
           // MyCommand = new RelayCommand(SayGreeting, CanExecute);
           GreetingModel_ = new GreetingModel();
           // GreetingModels_ = new ObservableCollection<GreetingModel>();
        }

        private GreetingModel _GreetingModel;

        public GreetingModel GreetingModel_
        {
            get { return _GreetingModel; }      
            set
            {
                _GreetingModel = value;
                NotifyPrpertyChanged("GreetingModel");
            }
        }



        private void SayGreeting()
        {
            GreetingModel_.Greeting = GreetingModel_.FirstName + "--- " + GreetingModel_.LastName;
        }

        private bool CanExecute()
        {
             return !string.IsNullOrEmpty(GreetingModel_.FirstName) & !string.IsNullOrEmpty(GreetingModel_.LastName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPrpertyChanged([CallerMemberName] string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
