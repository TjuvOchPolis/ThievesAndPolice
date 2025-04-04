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
    public Citizen(string name, int age, string gender, bool isRobbed, bool meetPolice) : base(name, age, gender)
    {
        IsRobbed = isRobbed;
        MeetPolice = meetPolice;
    }

    public bool IsRobbed { get; set; }
    public bool MeetPolice { get; set; }

    public override string Activity()
    {
        if (IsRobbed)
        {
            IsRobbed = false;
            Items.RemoveAt(0);
            return $"{Name} blev rånad";
        }

        if (MeetPolice)
        {
            MeetPolice = false;
            return ($"{Name} hälsar tillbaka");
        }

        return "Error när Citizen möter någon.";
    }

}
