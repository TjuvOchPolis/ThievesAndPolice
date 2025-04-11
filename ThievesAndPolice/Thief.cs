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

    public Stack<Item> ThiefInventory = new Stack<Item>();
    
    public bool IsArrested { get; set; }

    public override string Activity(string input)
    {
        return $"Tjuven {Name} tar föremålet {ThiefInventory.Peek().Name} ifrån stackars {input}             ";
    }


}
