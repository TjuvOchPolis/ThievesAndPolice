using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Police : Person
{
    public Police(string name, int[,] pos) : base(name, pos)
    {
        Name = name;
    }

    public List<Item> PoliceInventory = new List<Item>();

    public bool Arrest { get; set; }

    public bool isArresting { get; set; }
    public override void Activity()
    {
        Console.WriteLine($"Police: {Name} arresterar tjuven.");
        
    }

}
