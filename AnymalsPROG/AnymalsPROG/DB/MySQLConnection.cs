using AnymalsPROG.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
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

                string sql = "select * from cats union select * from dogs union select * from donkeys union select * from camels union select * from hamsters union select * from horses";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //AninalsList.Add(new Camel(reader["id"], reader["name"], reader["birthday"], reader["color"], null));
                            AninalsList.Add(new Camel(1, reader["name"].ToString(), DateTime.Now, reader["color"].ToString(), null));
                        }
                    }
                }

                connection.Close();
            }

            return AninalsList;
        }
    }
}
