using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Person
{
    public Person(string name, int[,] position)
    {
        Name = name;
        Position = position;
    }

    public string Name { get; set; }
    public int[,] Position { get; set; }
    public virtual void Activity()
    {

    }

}
