using AnymalsPROG.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace AnymalsPROG.DB
{
    internal class DBMySQLConnection : IDBConnection
    {
        private string connectionString;

        private static DBMySQLConnection instance;

        private DBMySQLConnection()
        { }

        public static DBMySQLConnection getInstance()
        {
            if (instance == null)
                instance = new DBMySQLConnection();
            return instance;
        }


        public void setConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Animals> getAllAnimals()
        {
            List<Animals> AninalsList = new List<Animals>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"

                    select all_animals.id, all_animals.Birthday, all_animals.name, colors.color, all_animals.animal_types_id
                    from(
                        select * from cats 
                        union
                        select * from dogs
                        union
                        select * from donkeys
                        union
                        select * from camels
                        union
                        select * from hamsters
                        union
                        select * from horses) as all_animals
                    left join colors on all_animals.color = colors.id
                    left join animals_types on all_animals.animal_types_id = animals_types.id
                    left join animal_classes on animals_types.animal_classes_id = animal_classes.id;";


                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AninalsList.Add(AnimalDBMaker.getAnimal(int.Parse(reader["id"].ToString()), reader["name"].ToString(), DateTime.Parse(reader["birthday"].ToString()), reader["color"].ToString(), (TypeAnimal)reader["animal_types_id"]));
                        }
                    }
                }

                connection.Close();
            }


            return AninalsList;
        }

        public Dictionary<int, string> getAllAnimalClasses()
        {
            Dictionary<int, string> AnimalClassesDictionary = new Dictionary<int, string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM human_friends.animal_classes;";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AnimalClassesDictionary.Add((int)reader["id"], reader["name"].ToString());
                        }
                    }
                }

                connection.Close();
            }

            return AnimalClassesDictionary;
        }

        public Dictionary<int, string> getAllAnimalTypes(int animalClass)
        {
            Dictionary<int, string> AnimalClassesDictionary = new Dictionary<int, string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"SELECT * FROM human_friends.animals_types where animal_classes_id = {animalClass}";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AnimalClassesDictionary.Add((int)reader["id"], reader["name"].ToString());
                        }
                    }
                }

                connection.Close();
            }

            return AnimalClassesDictionary;
        }

        /// <summary>
        /// Получения справочника цветов
        /// </summary>
        /// <returns>Dictionary<int, string></returns>
        public Dictionary<int, string> getAllAnimalColors()
        {
            Dictionary<int, string> AnimalClassesDictionary = new Dictionary<int, string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM human_friends.colors;";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AnimalClassesDictionary.Add((int)reader["id"], reader["color"].ToString());
                        }
                    }
                }

                connection.Close();
            }

            return AnimalClassesDictionary;
        }

        /// <summary>
        /// Добавляет животное в таблицу
        /// </summary>
        /// <returns></returns>
        public void createAnimal(int type, string name, DateTime birthday, int color)
        {

            string tableName = string.Empty;

            switch (type) 
            {
                case (int)TypeAnimal.Cat:
                    tableName = "cats";
                    break;
                case (int)TypeAnimal.Dog:
                    tableName = "dogs";
                    break;
                case (int)TypeAnimal.Hamster:
                    tableName = "hamsters";
                    break;
                case (int)TypeAnimal.Horse:
                    tableName = "horses";
                    break;
                case (int)TypeAnimal.Camel:
                    tableName = "camels";
                    break;
                case (int)TypeAnimal.Donkey:
                    tableName = "donkeys";
                    break;
            }

            Dictionary<int, string> AnimalClassesDictionary = new Dictionary<int, string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"INSERT INTO `{tableName}` (`name`, `Birthday`, `Color`, `animal_types_id`) VALUES ('{name}', '{birthday.ToString("yyyy-MM-dd")}', {color}, {type})";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
       
                }

                connection.Close();
            }

        }

        /// <summary>
        /// Удаляет животное из таблицы
        /// </summary>
        /// <returns></returns>
        public void deleteAnimal(Animals animal)
        {
            string tableName = string.Empty;

            switch (animal.animalType)
            {
                case (int)TypeAnimal.Cat:
                    tableName = "cats";
                    break;
                case (int)TypeAnimal.Dog:
                    tableName = "dogs";
                    break;
                case (int)TypeAnimal.Hamster:
                    tableName = "hamsters";
                    break;
                case (int)TypeAnimal.Horse:
                    tableName = "horses";
                    break;
                case (int)TypeAnimal.Camel:
                    tableName = "camels";
                    break;
                case (int)TypeAnimal.Donkey:
                    tableName = "donkeys";
                    break;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"DELETE FROM {tableName} WHERE id = {animal.id}";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();

                }

                connection.Close();
            }

        }

    }
}
