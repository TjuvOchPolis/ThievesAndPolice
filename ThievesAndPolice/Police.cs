using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Police : Person
{
    public Police(string name, int age, string gender, bool arrest, int[,] possition) : base(name, age, gender, possition)
    {
        Arrest = arrest;
    }

    public bool Arrest { get; set; }
    public List<Inventory> inventory = new List<Inventory>();

    public override void Interaction(Police police, Thieve thief)
    {    
        foreach (var item in thief.inventory)
        {
            police.inventory.Add(new Inventory(item.Item));
        }
        
        thief.inventory.Clear();
    }

}
