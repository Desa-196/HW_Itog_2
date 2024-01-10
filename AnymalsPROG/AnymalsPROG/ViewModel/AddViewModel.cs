using AnymalsPROG.DB;
using AnymalsPROG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnymalsPROG.ViewModel
{
    internal class AddViewModel :  INotifyPropertyChanged
    {
        IDBConnection dBConnection;

        public MainViewModel mainViewModel;

        public Dictionary<int, string> animalClesses { get; set; }
        public Dictionary<int, string> animalType { get; set; }
        public Dictionary<int, string> ColorList { get; set; }

        private DateTime birthday = DateTime.Now;
        public DateTime Birthday
        {
            get { return birthday; }
            set 
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        
        }

        private string name;
        public string Name 
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        
        }

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

        private KeyValuePair<int, string> selectedColor;
        public KeyValuePair<int, string> SelectedColor 
        {
            get { return selectedColor; }
            set 
            {
                selectedColor = value;
                OnPropertyChanged("SelectedColor");
            }
        
        }


        public MyCommand Create
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    dBConnection.createAnimal(SelectedType.Key, Name, Birthday, SelectedColor.Key);
                    mainViewModel.Update.Execute(null);
                    Close.Execute(obj);
                },
                (obj) =>
                {
                    return true;
                });
            }
        }

        public MyCommand Close
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    (obj as Window).Close();
                },
                (obj) =>
                {
                    return true;
                });
            }
        }

        public AddViewModel() 
        {
            dBConnection = DBMySQLConnection.getInstance();
            animalClesses = dBConnection.getAllAnimalClasses();
            ColorList = dBConnection.getAllAnimalColors();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
