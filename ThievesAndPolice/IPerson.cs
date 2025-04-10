using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal interface IPerson
{
    string Name { get; }
    int[,] Position { get; }
    public void Activity();
}
