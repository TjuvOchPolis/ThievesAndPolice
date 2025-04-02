using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Police : Person
{
    public Police(string name, int age, Queue<Inventory> inventory, string gender, string itemName, bool arrest, int[,] possition) : base(name, age, gender, itemName, possition)
    {
        Arrest = arrest;
    }

    public bool Arrest { get; set; }



}
