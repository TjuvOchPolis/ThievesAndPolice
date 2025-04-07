using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Thieve : Person
{
    public Thieve(string name, int age, string gender, bool arrested, int[,] possition) : base(name, age, gender,  possition)
    {
        Arrested = arrested;
    }

    public bool Arrested { get; set; }
    public List<Inventory> inventory = new List<Inventory>();

    public override void Interaction(Thieve thief, Citizen citizen)
    {
        var item = citizen.inventory[0];
        thief.inventory.Add(item);  
        citizen.inventory.RemoveAt(0);
    }
}
