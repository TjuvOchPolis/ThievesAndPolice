using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Prison
{

    public char[,] BuildPrison()
    {
        int width = 10;
        int height = 10;
        char[,] prison = new char[height, width];

        //Samma metod som BuildCity fast för mindre för fängelset
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                    prison[i, j] = '*';
                else
                    prison[i, j] = ' ';
            }
        }
        return prison;
    }
}
