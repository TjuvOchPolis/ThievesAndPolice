using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Person : Inventory
{
    public Person(string name, int age, string gender, List<Inventory> inventory, int[,] possition, string item) : base(item)
    {
        Name = name;
        Age = age;
        Inventory = inventory;
        Gender = gender;
        Possition = possition;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public List<Inventory> Inventory { get; set; }
    public string Gender { get; set; }
    public int[,] Possition { get; set; }

   
}
