using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Thieve : Person
{
    public Thieve(string name, int age, Queue<Inventory> inventory, string gender, string itemName, bool arrested, int[,] possition) : base(name, age, gender, itemName, possition)
    {
        Arrested = arrested;
    }

    public bool Arrested { get; set; }


}
