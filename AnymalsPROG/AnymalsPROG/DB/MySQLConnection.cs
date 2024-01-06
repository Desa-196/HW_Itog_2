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
    internal class MySQLConnection : IDBConnection
    {
       private string connectionString;

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
                            //AninalsList.Add(new Camel(reader["id"], reader["name"], reader["birthday"], reader["color"], null));
                           
                            AninalsList.Add(AnimalDBMaker.getAnimal(int.Parse(reader["id"].ToString()), reader["name"].ToString(), DateTime.Parse(reader["birthday"].ToString()), reader["color"].ToString(), (TypeAnimal)reader["animal_types_id"]));
                        }
                    }
                }

                connection.Close();
            }

            return AninalsList;
        }
    }
}
