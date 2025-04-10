using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ThievesAndPolice;
internal class Citizen : Person
{
    public Citizen(string name, int[,] pos) : base(name, pos)
    {
        CitizenInvetory.Push(new Item("Wallet"));
        CitizenInvetory.Push(new Item("Phone"));
        CitizenInvetory.Push(new Item("Money"));
        CitizenInvetory.Push(new Item("Watch"));
    }

    public Stack<Item> CitizenInvetory = new Stack<Item>(); 
    public bool IsRobbed { get; set; }
    public bool MeetPolice { get; set; }


    public override string Activity(string input)
    {
        return $"{Name} hälsar på farbror blå                                                                                                 ";
    }
}
