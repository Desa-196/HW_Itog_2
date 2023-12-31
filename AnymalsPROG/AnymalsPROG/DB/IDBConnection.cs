﻿using AnymalsPROG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnymalsPROG.DB
{
    internal interface IDBConnection
    {
        void setConnectionString(string connectionString);
        List<Animals> getAllAnimals();
        Dictionary<int, string> getAllAnimalClasses();
        Dictionary<int, string> getAllAnimalColors();
        Dictionary<int, string> getAllAnimalTypes(int animalClass);
        void createAnimal(int type, string name, DateTime birthday, int color);
    }
}
