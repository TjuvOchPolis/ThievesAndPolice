using System;
using System.Security.Cryptography;

namespace ThievesAndPolice
{
    internal class Program
    {
        public static List<Person> people = new List<Person>()
            {
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Thief("Lars", array()),
                new Citizen("Anders", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
                new Police("Gunnar", array()),
            };

        public static List<Thief> thiefPrison = new List<Thief>()
        {
        };

        public static Queue<string> que = new Queue<string>();
        public static List<string> News = new List<string>();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(60, 40);

            while (true)
            {
                Movement(); // Kordinater för City
                PrisonMovement(); // Kordinater för Prison

                Logic(); // Kordinater för City

               
                News.Reverse();
                int counter = 0;
                int number = 28;
                foreach (var item in News)
                {
                    //if(que.Count >= 5)
                    //{
                    //    que.Dequeue();
                    //}


                    if (counter < 4)
                    {
                        Console.SetCursorPosition(14, number);
                        Console.WriteLine(item);
                        counter++;
                        number++;
                    }

                }
                Console.ReadKey();
                Console.Clear();
            }
        }



        public static void Logic()
        {
            Console.SetCursorPosition(0, 0);


            int maxHeight = 27;
            int maxWidth = 52;

            char[,] city = new char[maxHeight, maxWidth];


            // PEOPLE INTERACTION LOGIC

            for (int i = 0; i < people.Count; i++)
            {
                for (int j = 0; j < people.Count; j++)
                {
                    if (people[i] is Police police)
                    {
                        if (people[j] is Thief thief && police.Position[0, 0] == thief.Position[0, 0] &&
                                police.Position[0, 1] == thief.Position[0, 1])
                        {
                            police.IsArresting = true;
                            thief.IsArrested = true;
                            if (thief.IsArrested)
                            {
                                List<Person> dump = new List<Person>();
                                
                                thiefPrison.Add(thief);
                                people.Remove(thief);
                            }

                            News.Add(new string(police.Activity()));
                            News.Add(thief.Activity());

                        }
                    }
                }
            }

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
                                if (x == person.Position[0, 0] && y == person.Position[0, 1] && person is Police police)
                                    symbol = 'P';
                                else if (x == person.Position[0, 0] && y == person.Position[0, 1] && person is Thief thief)
                                    symbol = 'T';
                                else if (x == person.Position[0, 0] && y == person.Position[0, 1] && person is Citizen citizen)
                                    symbol = 'C';
                            }
                        }
                        Console.SetCursorPosition(x, y);
                        Console.Write(symbol);
                    }
                    Console.WriteLine();
                }


            // PRISON
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
                                symbol = 'T';
                        }
                    }

                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            
        }

        public static void Movement()
        {
            Random rnd = new Random();
            foreach (var person in people)
            {
                int nextMove = rnd.Next(1, 8 + 1);
                switch (nextMove)
                {
                    case 1: person.Position[0, 0] += 1; break;
                    case 2: person.Position[0, 0] -= 1; break;
                    case 3: person.Position[0, 1] += 1; break;
                    case 4: person.Position[0, 1] -= 1; break;
                    case 5: person.Position[0, 0] += 1; person.Position[0, 1] += 1; break;
                    case 6: person.Position[0, 0] += 1; person.Position[0, 1] -= 1; break;
                    case 7: person.Position[0, 0] -= 1; person.Position[0, 1] -= 1; break;
                    case 8: person.Position[0, 0] -= 1; person.Position[0, 1] += 1; break;
                }


                //Math.Clamp sätter ett min och max värde för PositionX och PositionY så slipper man alla if klausuler
                person.Position[0, 0] = Math.Clamp(person.Position[0, 0], 1, 50); // x
                person.Position[0, 1] = Math.Clamp(person.Position[0, 1], 1, 25); // y

            }
        }

        public static void PrisonMovement()
        {
            Random rnd = new Random();
            foreach (Thief thief in thiefPrison)
            {
                int nextMove = rnd.Next(1, 8 + 1);
                switch (nextMove)
                {
                    case 1: thief.Position[0, 0] += 1; break;
                    case 2: thief.Position[0, 0] -= 1; break;
                    case 3: thief.Position[0, 1] += 1; break;
                    case 4: thief.Position[0, 0] += 1; thief.Position[0, 1] += 1; break;
                    case 6: thief.Position[0, 0] += 1; thief.Position[0, 1] -= 1; break;
                    case 7: thief.Position[0, 0] -= 1; thief.Position[0, 1] -= 1; break;
                    case 8: thief.Position[0, 0] -= 1; thief.Position[0, 1] += 1; break;
                }


                //Math.Clamp sätter ett min och max värde för PositionX och PositionY så slipper man alla if klausuler
                thief.Position[0, 0] = Math.Clamp(thief.Position[0, 0], 1, 10); // x
                thief.Position[0, 1] = Math.Clamp(thief.Position[0, 1], 1, 10); // y

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
