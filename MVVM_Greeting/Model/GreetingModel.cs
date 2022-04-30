using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Greeting.Model
{
    public class GreetingModel : INotifyPropertyChanged
    {

        private string _FirstName;
        

        public string FirstName
        {
            get { return _FirstName; }  
            set 
            { 
                _FirstName = value;
               NotifyPrpertyChanged("FirstName");
            }
        }


        private string _LastName;
        public string LastName
        {

            get { return _LastName; }
            set
            {
                _LastName = value;
              NotifyPrpertyChanged("LastName");
            }

        }

        private string _Greeting;
        public string Greeting
        {

            get { return _Greeting; }
            set
            {
                _Greeting = value;
                NotifyPrpertyChanged("Greeting");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPrpertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
