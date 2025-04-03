using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Person
{
    public Person(string name, int age, List<Inventory> inventory, string gender)
    {
        Name = name;
        Age = age;
        Inventory = inventory;
        Gender = gender;
    }


    public string Name { get; set; }
    public int Age { get; set; }
    List<Inventory> Inventory { get; set; }
    public string Gender { get; set; }
    public int PositionY { get; set; }
    public int PositionX { get; set; }

    public virtual string Activity()
    {
        return null;
    }
    public void StartPosition()
    {
        Random rnd = new Random();
        int[,] position = new int[PositionX, PositionY];

        PositionX = rnd.Next(0, 50 + 1);
        PositionY = rnd.Next(0, 25 + 1);

        int decider = rnd.Next(1, 5);

        if (decider == 1)
            PositionX = 0;
        else if (decider == 2)
            PositionX = 49;
        else if (decider == 3)
            PositionY = 0;
        else if (decider == 4)
            PositionY = 24;
    }
}
