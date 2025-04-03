﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ThievesAndPolice;
internal class Citizen : Person
{
    public Citizen(string name, int age, List<Inventory> inventory, string gender, bool isRobbed, bool meetPolice) : base(name, age, inventory, gender)
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
            return "Rånad";
        }

        if(MeetPolice)
        {
            MeetPolice = false;
            return ($"{Name} hälsar tillbaka");
        }

        else
        {
            return null;
        }
 
    }

}
