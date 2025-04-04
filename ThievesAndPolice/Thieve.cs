using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Thieve : Person
{
    public Thieve(string name, int age, List<Inventory> inventory, string gender,bool arrested) :base(name, age, inventory, gender)
    {
        IsArrested = arrested;
    }
    public bool IsArrested { get; set; }
    public bool IsRobbing { get; set; }


    public override string Activity()
    {
        IsArrested = true;
        return $"Thief:             {Name} has been arrested!\n";
    }
}
