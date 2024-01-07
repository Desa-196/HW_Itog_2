using AnymalsPROG.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnymalsPROG.ViewModel
{
    internal class AddViewModel :  INotifyPropertyChanged
    {
        IDBConnection dBConnection;

        public Dictionary<int, string> animalClesses { get; set; }
        public Dictionary<int, string> animalType { get; set; }

        private KeyValuePair<int, string> selectedClass;
        public KeyValuePair<int, string> SelectedClass 
        {
            get { return selectedClass; }
            set 
            { 
                selectedClass = value;
                animalType = dBConnection.getAllAnimalTypes(selectedClass.Key);
                OnPropertyChanged("animalType");
                OnPropertyChanged("SelectedClass");
            }
        
        }

        private KeyValuePair<int, string> selectedType;
        public KeyValuePair<int, string> SelectedType 
        {
            get { return selectedType; }
            set 
            {
                selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        
        }


        public AddViewModel() 
        {
            dBConnection = DBMySQLConnection.getInstance();
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
