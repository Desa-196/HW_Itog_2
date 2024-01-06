using AnymalsPROG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnymalsPROG.DB
{
    static  class AnimalDBMaker
    {
        public static Animals getAnimal(int id, string name, DateTime birthday, string color, TypeAnimal typeAnimal) 
        {
            switch (typeAnimal)
            {
                case TypeAnimal.Cat:
                    return new Cat(id, name, birthday, color, null);
                case TypeAnimal.Dog:
                    return new Dog(id, name, birthday, color, null);
                case TypeAnimal.Hamster:
                    return new Hamster(id, name, birthday, color, null);
                case TypeAnimal.Camel:
                    return new Camel(id, name, birthday, color, null);
                case TypeAnimal.Horse:
                    return new Horse(id, name, birthday, color, null);
                case TypeAnimal.Donkey:
                    return new Donkey(id, name, birthday, color, null);
                default: return null;

            }
        }
    }
}
