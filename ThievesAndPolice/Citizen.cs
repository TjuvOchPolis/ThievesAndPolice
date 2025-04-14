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
        CitizenInvetory.Push(new Item("Plånbok"));
        CitizenInvetory.Push(new Item("Telefon"));
        CitizenInvetory.Push(new Item("Pengar"));
        CitizenInvetory.Push(new Item("Klocka"));
    }

    public Stack<Item> CitizenInvetory = new Stack<Item>(); 
    public bool IsRobbed { get; set; }
    public bool MeetPolice { get; set; }


    public override string Activity(string input)
    {
        return $"{Name} hälsar på farbror blå                                                                                        ";
    }
}
