using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThievesAndPolice
{
    internal class Program
    {
        static Random random = new Random();

        static int possitionX = random.Next(1, 49);
        static int possitionY = random.Next(0, 23);
        static int possitionThiefX = random.Next(1, 49);
        static int possitionThiefY = random.Next(0, 23);
        static int possitionPoliceX = random.Next(1, 49);
        static int possitionPoliceY = random.Next(0, 23);

        static List<Person> persons = new List<Person>();

        static public bool kont = false;
        static string NAMES = "";

        static void Main(string[] args)
        {
            Prison prison = new Prison();
            static int[,] array()
            {
                return new int[,]
                { { RandomX(), RandomY() } };
            }
            static int RandomX()
            {
                // Returnerar ett random nummer mellan 1 och 48 för X-axeln
                return random.Next(1, 49);
            }
            static int RandomY()
            {
                // Returnerar ett random nummer mellan 0 och 22 för Y-axeln
                return random.Next(0, 23);
            }

            List<Inventory> inventory = new List<Inventory>();
            inventory.Add(new Inventory("Väska"));
            inventory.Add(new Inventory("Plånbok"));
            inventory.Add(new Inventory("Pengar"));
            inventory.Add(new Inventory("Klocka"));

            persons.Add(new Citizen("Christofer", 33, "Male", inventory, false, false, array()));
            persons.Add(new Citizen("Koffe", 3, "Male", inventory, false, false, array()));
            persons.Add(new Citizen("Lisa", 58, "Female", inventory, false, false, array()));
            persons.Add(new Thieve("Svensson", 16, "Female", inventory, false, array()));
            persons.Add(new Thieve("Svensson", 16, "Female", inventory, false, array()));
            persons.Add(new Thieve("Svensson", 16, "Female", inventory, false, array()));
            persons.Add(new Thieve("Svensson", 16, "Female", inventory, false, array()));
            persons.Add(new Thieve("Svensson", 16, "Female", inventory, false, array()));

            persons.Add(new Police("Johansson", 22, "Female", inventory, false, array()));
            //persons.Add(new Citizen("Albin", 11, "Male", inventory, false, false, array()));




            while (true)
            {
                Console.Clear();
                MovePatter();
                if (kont)
                {
                    Console.WriteLine("ITEM SNODD");
                    kont = false;
                    Console.WriteLine(NAMES);
                }
                Console.ReadKey();
            }




        }

        static public void MovePatter()
        {
            Console.CursorVisible = false;
            Random rnd = new Random();

            int moveX = rnd.Next(-1, 2);
            int moveY = rnd.Next(-1, 2);

            // en kontroll för att inte låta gubben stå helt stilla utan alltid röra sig MINST 1 steg någonstans
            if (moveX == 0 && moveY == 0)
            {
                int controll = rnd.Next(0, 2);
                int controll2 = rnd.Next(0, 2);

                switch (controll)
                {
                    case 0:
                        if (controll2 == 0)
                            moveX = -1;
                        else
                            moveX = 1;
                        break;

                    case 1:
                        if (controll2 == 0)
                            moveY = -1;
                        else
                            moveY = 1;
                        break;
                }
            }

            foreach (Person person in persons)
            {
                person.Possition[0, 0] = Possition("X", person.Possition[0, 0]);
                person.Possition[0, 1] = Possition("Y", person.Possition[0, 1]);
            }


            for (int i = 0; i < 50; i++)
            {
                if (i == 2 || i == 7)
                    Console.Write(" ");
                else if (i == 3 || i == 4 || i == 5 || i == 6)
                {
                    switch (i)
                    {
                        case 3:
                            Console.Write("C");
                            break;
                        case 4:
                            Console.Write("I");
                            break;
                        case 5:
                            Console.Write("T");
                            break;
                        case 6:
                            Console.Write("Y");
                            break;
                    }
                }
                else
                    Console.Write("#");
            }



            for (int j = 0; j < 23; j++)
            {
                Console.WriteLine();
                for (int i = 0; i < 50; i++)
                {
                    if (i == 0)
                        Console.Write("#");
                    else if (i == 49)
                        Console.Write("#");
                    else
                    {
                        int number1 = 0;
                        int number2 = 0;
                        int number3 = 0;

                        bool check = false;

                        foreach (Person person in persons)
                        {
                            foreach (Person person2 in persons)
                            {                                
                                if (i == person.Possition[0, 0] && person is Citizen)
                                {
                                    if (j == person.Possition[0, 1] && number1 < 1)
                                    {
                                        number1++;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("C"); // Logik för att printa ut Medborgare
                                        Console.ResetColor();
                                        check = true;
                                    }
                                }

                                if (i == person.Possition[0, 0] && person is Thieve)
                                {
                                    if (i == person.Possition[0, 0] && i == person2.Possition[0, 0] && j == person.Possition[0, 1] && j == person2.Possition[0, 1] && person2 is Citizen)
                                    {
                                        //Logik om Medborgare och Tjuv hamnar på samma kordinater, så snor tjuven om det finns saker att sno
                                        number2++;
                                        person.Inventory.Add(person2.Inventory[0]);
                                        person2.Inventory.RemoveAt(0);
                                        kont = true;
                                        check = true;
                                        NAMES = $"Namn: {person.Name} - {person2.Name}, Kordinat: X:{person.Possition[0, 0]} Y:{person.Possition[0, 1]} - X:{person2.Possition[0, 0]} Y:{person2.Possition[0, 1]}";
                                    }
                                    else if (i == person.Possition[0, 0] && i == person2.Possition[0, 0] && j == person.Possition[0, 1] && j == person2.Possition[0, 1] && person2 is Police)
                                    {
                                        number2++;
                                        check = true;
                                    }
                                    else if (j == person.Possition[0, 1] && number2 < 1 && j != person2.Possition[0, 1] && person2 is not Citizen)
                                    {
                                        number2++;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("T");
                                        Console.ResetColor();
                                        check = true;
                                    }
                                }

                                if (i == person.Possition[0, 0] && person is Police)
                                {
                                    if (i == person.Possition[0, 0] && i == person2.Possition[0, 0] && j == person.Possition[0, 1] && j == person2.Possition[0, 1] && person2 is Citizen)
                                    {
                                        check = true;
                                        number3++;
                                    }
                                    else if (i == person.Possition[0, 0] && i == person2.Possition[0, 0] && j == person.Possition[0, 1] && j == person2.Possition[0, 1] && person2 is Thieve)
                                    {
                                        check = true;
                                        number3++;
                                        Console.WriteLine("TJUV TILL FÄNGELSE"); // här kommer logit för när en tjuv blir tagen
                                    }
                                    else if (j == person.Possition[0, 1] && number3 < 1 && j != person2.Possition[0, 1])
                                    {
                                        number3++;
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write("P");
                                        Console.ResetColor();
                                        check = true;
                                    }
                                }
                            }

                        }

                        if (check == false)
                            Console.Write(" ");

                        check = false;
                    }
                }
            }

            Console.WriteLine();
            for (int i = 0; i < 50; i++)
            {
                if (i == 1 || i == 8)
                    Console.Write(" ");
                else if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7)
                {
                    switch (i)
                    {
                        case 2:
                            Console.Write("P");
                            break;
                        case 3:
                            Console.Write("R");
                            break;
                        case 4:
                            Console.Write("I");
                            break;
                        case 5:
                            Console.Write("S");
                            break;
                        case 6:
                            Console.Write("O");
                            break;
                        case 7:
                            Console.Write("N");
                            break;
                    }
                }
                else
                    Console.Write("#");
            }

            // PRISON
            for (int j = 0; j < 8; j++)
            {
                Console.WriteLine();
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                        Console.Write("#");
                    else if (i == 9)
                        Console.Write("#");
                    else
                    {
                        if (1 == 2)
                            Console.WriteLine("Hej"); // Logik för att printa ut Tjuvarna som blivit tagna
                        else
                            Console.Write(" ");
                    }
                }
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
                Console.Write("#");

        }




        static public int Possition(string angle, int number)
        {
            Random rnd = new Random();

            int moveX = rnd.Next(-1, 2);
            int moveY = rnd.Next(-1, 2);

            // en kontroll för att inte låta gubben stå helt stilla utan alltid röra sig MINST 1 steg någonstans
            if (moveX == 0 && moveY == 0)
            {
                int controll = rnd.Next(0, 2);
                int controll2 = rnd.Next(0, 2);

                switch (controll)
                {
                    case 0:
                        if (controll2 == 0)
                            moveX = -1;
                        else
                            moveX = 1;
                        break;

                    case 1:
                        if (controll2 == 0)
                            moveY = -1;
                        else
                            moveY = 1;
                        break;
                }
            }

            int move = 0;


            if (moveX == -1)
                move = number - 1;
            else if (moveX == 1)
                move = number + 1;
            else
                move = number;


            // kontroller för att inte få pjäsen att hamna utanför
            if (angle == "X")
            {
                if (move < 1)
                    move = 1;
                else if (move == 49)
                    move = 48;
            }
            else if (angle == "Y")
            {
                if (move < 1)
                    move = 1;
                else if (move == 23)
                    move = 22;
            }

            return move;
        }
    }
}
