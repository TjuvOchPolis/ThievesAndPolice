using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class City
{
    public char[,] BuildCity()
    {
        int width = 50;
        int height = 25;
        char[,] box = new char[height, width];

        //Bygger staden och sätter kanterna till '*'
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                    box[i, j] = '*';
                else
                    box[i, j] = ' ';
            }
        }
        return box;
    }
}





