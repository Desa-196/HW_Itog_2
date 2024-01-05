using AnymalsPROG.DB;
using AnymalsPROG.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnymalsPROG.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {

        private List<Animals> _animalsList = new List<Animals>();
        public List<Animals> AnimalsList
        {
            get
            {
                return _animalsList;
            }
            set
            {
                _animalsList = value;
                OnPropertyChanged("AnimalsList");
            }
        }

        public MainViewModel()
        {
            IDBConnection dBConnection = new MySQLConnection();
            dBConnection.setConnectionString("server=localhost;database=animals;uid=animals_user;password=p-Ze9ho8EC;");
            AnimalsList = dBConnection.getAllAnimals();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
