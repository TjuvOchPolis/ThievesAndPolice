using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Inventory
{
    public string ItemName { get; set; }

    public Inventory(string itemName)
    {
        ItemName = itemName;
    }
}
