using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Thief : Person
{
    public Thief(string name, int[,] pos) : base(name, pos)
    {
    }

    public List<Item> ThiefInventory = new List<Item>();
    
    public bool IsArrested { get; set; }

    public override string Activity(string input)
    {
        if (IsArrested)
        {
            IsArrested = false;
            return $"Thief: {Name} blir arresterad";
        }
        return base.Activity("");
    }


}
