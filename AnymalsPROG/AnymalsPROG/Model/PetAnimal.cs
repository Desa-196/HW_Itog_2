using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnymalsPROG.Model
{
    internal abstract class PetAnimal : Animals
    {
        public PetAnimal(int id, string name, DateTime birthday, string color, List<Command> command) : base(id, name, birthday, color, command) { }
    }
}
