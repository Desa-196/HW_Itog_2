using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnymalsPROG.Model
{
    internal abstract class Animals
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime birthday { get; set; }
        public string color {  get; set; }
        public List<Command> commands { get; set; }
        public void LernCommand(Command command) 
        {
            commands.Add(command);
        }
    }
}
