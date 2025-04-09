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
        CitizenInvetory.Add(new Item("Wallet"));
        CitizenInvetory.Add(new Item("Phone"));
        CitizenInvetory.Add(new Item("Money"));
        CitizenInvetory.Add(new Item("Watch"));
    }

    public List<Item> CitizenInvetory = new List<Item>(); 
    public bool IsRobbed { get; set; }
    public bool MeetPolice { get; set; }
    public override void Activity()
    {

    }
}
