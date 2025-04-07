using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Person
{
    public Person(string name, int age, string gender, int[,] possition)
    {
        Name = name;
        Age = age;        
        Gender = gender;
        Possition = possition;
    }

    public string Name { get; set; }
    public int Age { get; set; }
   
    public string Gender { get; set; }
    public int[,] Possition { get; set; }

    public virtual void Interaction()
    {

    }
    public virtual void Interaction(Thieve thief, Citizen citizen)
    {
    }
}
