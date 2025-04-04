using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice
{
    internal class Police : Person
    {
        public Police(string name, int age, List<Inventory> inventory, string gender, bool arrest) : base(name, age, inventory, gender)
        {
            IsArresting = arrest;
        }

        public bool IsArresting { get; set; }
        public bool MeetCitizen { get; set; }

        public override string Activity()
        {
            if (IsArresting)
            {
                IsArresting = false;


                return $"Police:            {Name} arrested thief.";
            }
            else if (MeetCitizen)
            {
                MeetCitizen = false;
                return $"Police:            {Name} hälsar på citizen!";
            }
            else
            {
                return null;
            }
        }
    }
}