﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnymalsPROG.Model
{
    internal class Cat:PetAnimal
    {
        public Cat(int id, string name, DateTime birthday, string color, List<Command> command) : base(id, name, birthday, color, command) 
        {
            img = "/Img/cat.png";
        }
    }
}
