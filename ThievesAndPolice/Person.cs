using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Person : Inventory
{
    public Person(string name, int age, string gender, string itemName, int[,] possition) : base(itemName)
    {
        Name = name;
        Age = age;
        //Inventory = inventory;
        Gender = gender;
        Possition = possition;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Inventory { get; set; }
    public string Gender { get; set; }
    public int[,] Possition { get; set; }

   
}
