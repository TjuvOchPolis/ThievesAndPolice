using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Item
{
	public string Type {  get; set; }

    public Item(string type)
    {
        Type = type;
    }
}
