using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Person : Inventory
{
    public Person(string name, int age, Queue<Inventory> inventory, string gender)
    {
        Name = name;
        Age = age;
        Inventory = inventory;
        Gender = gender;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    Queue <Inventory> Inventory { get; set; }
    public string Gender { get; set; }

}
