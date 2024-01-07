using AnymalsPROG.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnymalsPROG.ViewModel
{
    internal class AddViewModel :  INotifyPropertyChanged
    {

        public Dictionary<int, string> animalClesses { get; set; }

        private KeyValuePair<int, string> selectedClass;
        public KeyValuePair<int, string> SelectedClass 
        {
            get { return selectedClass; }
            set 
            { 
                selectedClass = value;
                OnPropertyChanged("SelectedClass");
            }
        
        }


        public AddViewModel() 
        {
            IDBConnection dBConnection = DBMySQLConnection.getInstance();
            animalClesses = dBConnection.getAllAnimalClasses();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
