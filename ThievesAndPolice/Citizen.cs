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
    public Citizen(string name, int age, string gender,  bool isRobbed, bool meetPolice, int[,] possition) : base(name, age, gender,  possition)
    {
        IsRobbed = isRobbed;
        MeetPolice = meetPolice;
        inventory.Add(new Inventory("Väska"));
        inventory.Add(new Inventory("Plånbok"));
        inventory.Add(new Inventory("Pengar"));
        inventory.Add(new Inventory("Klocka"));
    }
    public List<Inventory> inventory = new List<Inventory>();
    public bool IsRobbed { get; set; }
    public bool MeetPolice { get; set; }
    

    public override void Interaction()
    {

    }
}
