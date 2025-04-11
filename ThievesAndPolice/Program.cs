using System;
using System.Security.Cryptography;

namespace ThievesAndPolice
{
    internal class Program
    {
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

        public static List<Person> people = new List<Person>()
            {
                new Citizen("Philip", array()),
                new Citizen("Christofer", array()),
                new Citizen("Viktor", array()),
                new Citizen("Johannes", array()),
                new Citizen("Lisa", array()),
                new Citizen("Adam", array()),
                new Citizen("Eva", array()),
                new Citizen("Putin", array()),
                new Citizen("Trump", array()),
                new Citizen("Vladimir", array()),
                new Citizen("Jesus", array()),
                new Citizen("Johan", array()),
                new Citizen("Sara", array()),
                new Citizen("Johanna", array()),
                new Citizen("Åsa", array()),
                new Citizen("Anders", array()),
                new Citizen("Markus", array()),
                new Citizen("Dominik", array()),
                new Citizen("Evenlina", array()),
                new Citizen("Lennart", array()),

                // Alla tjuvar har ju Aliases
                new Thief("gr3k3n", array()),
                new Thief("den fete", array()),
                new Thief("Korven", array()),
                new Thief("Tjorven", array()),
                new Thief("Glömsker", array()),
                new Thief("Blyger", array()),
                new Thief("Prosit", array()),
                new Thief("Glader", array()),
                new Thief("Butter", array()),
                new Thief("Toker", array()),
                new Thief("Trötter", array()),
                new Thief("Mästaren", array()),

                new Police("Johansson", array()),
                new Police("Johansson", array()),
                new Police("Johansson", array()),
                new Police("Johansson", array()),
                new Police("Johansson", array()),
                new Police("Johansson", array()),
            };

        public static List<Thief> thiefPrison = new List<Thief>()
        {
        };

        static Stack<string> NewsFeed = new Stack<string>();




        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(60, 40);

            while (true)
            {
                Movement(); // Kordinater för City
                PrisonMovement(); // Kordinater för Prison

                Logic(); // Kordinater för City

                Newsfeed();

                //Console.ReadKey();
                //Console.Clear();
            }
        }



        public static void Logic()
        {
            Console.SetCursorPosition(0, 0);
            List<Person> toDelete = new List<Person>();

            int maxHeight = 27;
            int maxWidth = 52;

            char[,] city = new char[maxHeight, maxWidth];

            Stack<Item> items = new Stack<Item>();
            string name = "";
            // PEOPLE INTERACTION LOGIC

            for (int i = 0; i < people.Count; i++)
            {                
                for (int j = 0; j < people.Count; j++)
                {
                    if (people[i] is Police police)
                    {
                        if (people[j] is Thief thief && police.Position[0, 0] == thief.Position[0, 0] &&
                                police.Position[0, 1] == thief.Position[0, 1] && thief.ThiefInventory.Count > 0)
                        {
                            police.IsArresting = true;
                            thief.IsArrested = true;

                            if (thief.IsArrested)
                            {
                                if (thief.ThiefInventory.Count > 0)
                                {
                                    foreach (var item in thief.ThiefInventory)
                                    {
                                        police.PoliceInventory.Push(item);
                                    }
                                    thief.ThiefInventory.Clear();
                                }

                                thiefPrison.Add(thief);
                                toDelete.Add(thief);
                            }

                            NewsFeed.Push(police.Activity(thief.Name));

                        }
                    }
                    else if (people[i] is Thief thief)
                    {
                        if (people[j] is Citizen citizen && thief.Position[0, 0] == citizen.Position[0, 0] &&
                                thief.Position[0, 1] == citizen.Position[0, 1] && citizen.CitizenInvetory.Count > 0)
                        {
                            name = citizen.Name;                            
                            items.Push(citizen.CitizenInvetory.Peek());
                            thief.ThiefInventory.Push(items.Peek());

                            NewsFeed.Push(thief.Activity(citizen.Name));
                        }
                    }
                    else if (people[i] is Citizen citizen)
                    {
                        if (people[j] is Police police2 && citizen.Position[0, 0] == police2.Position[0, 0] &&
                              citizen.Position[0, 1] == police2.Position[0, 1])
                        {

                            NewsFeed.Push(citizen.Activity(police2.Name));
                        }

                    }
                }
            }

            foreach (var person in people)
            {
                if (person is Citizen citizen && citizen.Name == name)
                    citizen.CitizenInvetory.Pop();
            }
            

            // För att programmet INTE skall krasha
            foreach (var p in toDelete)
            {
                people.Remove(p);
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
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                symbol = 'P';
                            }
                            else if (x == person.Position[0, 0] && y == person.Position[0, 1] && person is Thief thief)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                symbol = 'T';
                            }
                            else if (x == person.Position[0, 0] && y == person.Position[0, 1] && person is Citizen citizen)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                symbol = 'C';
                            }
                        }
                    }
                    Console.SetCursorPosition(x, y);
                    Console.Write(symbol);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }


            // PRISON
            Prison.PrisonLogic(thiefPrison);

        }

        public static void Newsfeed()
        {
            int counter = 0;
            int number = 28; // till för att sätta vart utskriften skall vara
            Console.SetCursorPosition(14, 27);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Nyheter: ");
            Console.ResetColor();

            if (NewsFeed.Count > 0)
            {
                foreach (var news in NewsFeed)
                {
                    if (counter < 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.SetCursorPosition(14, number);
                        Console.WriteLine(news);
                        Console.ResetColor();
                        counter++;
                        number++;
                    }
                }
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

    }
}
