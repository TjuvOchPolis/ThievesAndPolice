using System;

namespace ThievesAndPolice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Thief("Lars", array()),
                new Citizen("Anders", array()),
                new Police("Gunnar", array()),
            };
            int maxHeight = 25;
            int maxWidth = 50;

            char[,] city = new char[maxHeight, maxWidth];

            for (int x = 0; x < city.GetLength(0); x++)
            {
                for (int y = 0; y < city.GetLength(1); y++)
                {
                    char symbol = city[x, y];
                    if (x == 0 || x == maxHeight - 1 || y == 0 || y == maxWidth - 1)
                        symbol = '*';
                    else
                        symbol = ' ';

                    foreach (Person person in people)
                    {
                        if (symbol == ' ')
                        {
                            if (city[x,y] == person.Position[x, y] && person is Police)
                                symbol = 'P';
                            else if (city[x, y] == person.Position[x, y] && person is Thief)
                                symbol = 'T';
                            else if (city[x, y] == person.Position[x, y] && person is Citizen)
                                symbol = 'C';
                        }
                    }

                    Console.Write(city[x, y]);
                }
                Console.WriteLine();
            }

            int maxHeightPrison = 10;
            int maxWidthPrison = 10;

            char[,] prison = new char[maxHeightPrison, maxWidthPrison];

            for (int x = 0; x < prison.GetLength(0); x++)
            {
                for (int y = 0; y < prison.GetLength(1); y++)
                {
                    if (x == 0 || x == maxHeightPrison - 1 || y == 0 || y == maxWidthPrison - 1)
                        prison[x, y] = '*';
                    else
                        prison[x, y] = ' ';


                    Console.Write(prison[x, y]);
                }
                Console.WriteLine();
            }
        }
        static int[,] array()
        {
            return new int[,]
            { { RandomX(), RandomY() } };
        }
        static int RandomX()
        {
            // Returnerar ett random nummer mellan 1 och 48 för X-axeln
            return Random.Shared.Next(1, 49);
        }
        static int RandomY()
        {
            // Returnerar ett random nummer mellan 0 och 22 för Y-axeln
            return Random.Shared.Next(0, 23);
        }
    }
}
