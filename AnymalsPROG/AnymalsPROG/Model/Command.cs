using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnymalsPROG.Model
{
    internal class Command
    {
        public int id { get; set; }
        public string name { get; set; }
        public void Run()
        {
            System.Windows.MessageBox.Show(name);
        }
    }
}
