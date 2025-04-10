using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Map
{
    public char[,] BuildCity()
    {
        int maxHeight = 25;
        int maxWidth = 50;

        char[,] city = new char[maxHeight, maxWidth];

        for (int x = 0; x < city.GetLength(0); x++)
        {
            for (int y = 0; y < city.GetLength(1); y++)
            {
                if (x == 0 || x == maxHeight - 1 || y == 0 || y == maxWidth - 1)
                    city[x, y] = '*';
                else
                    city[x, y] = ' ';
            }
        }
        return city;
    }

  
}
