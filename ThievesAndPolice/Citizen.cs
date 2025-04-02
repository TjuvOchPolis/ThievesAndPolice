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
    public Citizen(string name, int age, string gender, string itemName, bool isRobbed, bool meetPolice, int[,] possition) : base(name, age, gender, itemName, possition)
    {
        IsRobbed = isRobbed;
        MeetPolice = meetPolice;
    }

    public bool IsRobbed { get; set; }
    public bool MeetPolice { get; set; }
    


}
