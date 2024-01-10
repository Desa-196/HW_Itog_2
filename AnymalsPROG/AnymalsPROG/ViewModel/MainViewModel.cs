using AnymalsPROG.DB;
using AnymalsPROG.Model;
using AnymalsPROG.View;
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
    internal class MainViewModel : INotifyPropertyChanged
    {

        private IDBConnection dBConnection;

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

        public MyCommand Add
        {
            get
            {
                return new MyCommand((obj) =>
                {

                    var newWindow = new Add();
                    newWindow.ShowDialog();
                    newWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                },
                (obj) =>
                {
                    return true;
                });
            }
        }

        public MyCommand Delete
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    dBConnection.deleteAnimal(obj as Animals);
                    AnimalsList = dBConnection.getAllAnimals();
                    OnPropertyChanged("AnimalsList");
                },
                (obj) =>
                {
                    return true;
                });
            }
        }

        public MyCommand Update
        {
            get
            {
                return new MyCommand((obj) =>
                {
                    AnimalsList = dBConnection.getAllAnimals();
                    OnPropertyChanged("AnimalsList");
                },
                (obj) =>
                {
                    return true;
                });
            }
        }

        public MainViewModel()
        {
            dBConnection = DBMySQLConnection.getInstance();
            dBConnection.setConnectionString("server=localhost;database=human_friends;uid=animals_user;password=p-Ze9ho8EC;");
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
