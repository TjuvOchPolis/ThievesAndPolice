using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Prison
{
    public static void PrisonLogic(List<Thief> thiefPrison)
    {
        int maxHeightPrison = 12;
        int maxWidthPrison = 12;

        char[,] prison = new char[maxHeightPrison, maxWidthPrison];

        for (int x = 1; x < prison.GetLength(0); x++)
        {
            for (int y = 0; y < prison.GetLength(1); y++)
            {
                char symbol = prison[x, y];
                if (x == 0 || x == maxHeightPrison - 1 || y == 0 || y == maxWidthPrison - 1)
                    symbol = '*';
                else
                    symbol = ' ';

                if (symbol == ' ')
                {
                    foreach (Thief thief in thiefPrison)
                    {
                        if (x == thief.Position[0, 0] && y == thief.Position[0, 1])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            symbol = 'T';
                        }
                    }
                }

                Console.Write(symbol);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
