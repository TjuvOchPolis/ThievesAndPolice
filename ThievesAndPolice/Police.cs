using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Police : Person
{
    public Police(string name, int age, string gender, bool arrest) : base(name, age, gender)
    {
        IsArresting = arrest;
    }

    public bool IsArresting { get; set; }
    public bool MeetCitizen { get; set; }

    public override string Activity()
    {
        if (MeetCitizen)
        {
            MeetCitizen = false;
            return $"{Name} hälsar på citizen. ";
        }
        else if (IsArresting)
        {
            return $"{Name} arresterar :";
        }

        return "Error när Police möter någon.";
    }
}
