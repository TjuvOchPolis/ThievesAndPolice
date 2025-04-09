using System;
using System.Security.Cryptography;

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
            int maxHeight = 27;
            int maxWidth = 52;

            char[,] city = new char[maxHeight, maxWidth];


            Console.WriteLine("X: " + people[1].Position[0, 0]);
            Console.WriteLine("Y: " + people[1].Position[0, 1]);

            for (int y = 0; y < city.GetLength(0); y++)
            {
                for (int x = 0; x < city.GetLength(1); x++)
                {
                    char symbol = city[y, x];
                    if (x == 0 || y == maxHeight - 1 || y == 0 || x == maxWidth - 1)
                        symbol = '*';
                    else
                        symbol = ' ';

                    
                    if (symbol == ' ')
                    {
                        foreach (Person person in people)
                        {
                            if (x == person.Position[0, 0] && y == person.Position[0, 1] && person is Police)
                                symbol = 'P';
                            else if (x == person.Position[0, 0] && y == person.Position[0, 1] && person is Thief)
                                symbol = 'T';
                            else if (x == person.Position[0, 0] && y == person.Position[0, 1] && person is Citizen)
                                symbol = 'C';
                        }
                    }

                    Console.Write(symbol);
                }
                Console.WriteLine();
            }

            int maxHeightPrison = 12;
            int maxWidthPrison = 12;

            char[,] prison = new char[maxHeightPrison, maxWidthPrison];

            for (int x = 1; x < prison.GetLength(0); x++)
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
