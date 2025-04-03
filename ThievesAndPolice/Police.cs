using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Police : Person
{
    public Police(string name, int age, string gender, List<Inventory> inventory, bool arrest, int[,] possition) : base(name, age, gender, inventory, possition)
    {
        Arrest = arrest;
    }

    public bool Arrest { get; set; }



}
