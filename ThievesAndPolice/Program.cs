using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThievesAndPolice
{
    internal class Program
    {
        static Random random = new Random();

        static List<Person> persons = new List<Person>();

        static public bool kont = false;
        static string NAMES = "";
        static int längd = 0;
        static int längd2 = 0;

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

            // Medborgare
            persons.Add(new Citizen("Christofer", 33, "Male", false, false, array()));
            persons.Add(new Citizen("Koffe", 3, "Male", false, false, array()));
            persons.Add(new Citizen("Lisa", 58, "Female", false, false, array()));
            persons.Add(new Citizen("Viktor", 33, "Male", false, false, array()));
            persons.Add(new Citizen("Johannes", 3, "Male", false, false, array()));
            persons.Add(new Citizen("Philip", 58, "Female", false, false, array()));
            persons.Add(new Citizen("Dominik", 33, "Male", false, false, array()));
            persons.Add(new Citizen("Mackan", 3, "Male", false, false, array()));
            persons.Add(new Citizen("Jennifer", 58, "Female", false, false, array()));
            persons.Add(new Citizen("Eve", 33, "Male", false, false, array()));
            persons.Add(new Citizen("Crack-1", 3, "Male", false, false, array()));
            persons.Add(new Citizen("Crack-23", 58, "Female", false, false, array()));
            persons.Add(new Citizen("Namn", 33, "Male", false, false, array()));
            persons.Add(new Citizen("Name31", 3, "Male", false, false, array()));
            persons.Add(new Citizen("Slut-På-Namn", 58, "Female", false, false, array()));
            persons.Add(new Citizen("EN-TILL", 33, "Male", false, false, array()));
            persons.Add(new Citizen("ALDRIG-SLUT?", 3, "Male", false, false, array()));
            persons.Add(new Citizen("Snart", 58, "Female", false, false, array()));
            persons.Add(new Citizen("Så", 33, "Male", false, false, array()));
            persons.Add(new Citizen("Äntligen", 81, "Male", false, false, array()));

            // Tjuvar
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));
            persons.Add(new Thieve("Jönsson", 16, "Female", false, array()));

            //Poliser
            persons.Add(new Police("Johansson", 22, "Female", false, array()));
            persons.Add(new Police("Johansson", 22, "Female", false, array()));
            persons.Add(new Police("Johansson", 22, "Female", false, array()));
            persons.Add(new Police("Johansson", 22, "Female", false, array()));
            persons.Add(new Police("Johansson", 22, "Female", false, array()));
            persons.Add(new Police("Johansson", 22, "Female", false, array()));





            while (true)
            {
                Console.Clear();
                MovePatter();
                if (kont)
                {
                    Console.WriteLine("ITEM SNODD");
                    kont = false;
                    Console.WriteLine(NAMES);
                    Console.WriteLine($"SAKERSNODDA: {längd}");
                    Console.WriteLine($"SAKER KVAR: {längd2}");
                    Console.ReadKey();
                }
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



            for (int x = 0; x < 23; x++)
            {
                Console.WriteLine();
                for (int y = 0; y < 50; y++)
                {
                    if (y == 0)
                        Console.Write("#");
                    else if (y == 49)
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
                                if (y == person.Possition[0, 0] && person is Citizen)
                                {
                                    if (x == person.Possition[0, 1] && number1 < 1)
                                    {
                                        number1++;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("C"); // Logik för att printa ut Medborgare
                                        Console.ResetColor();
                                        check = true;

                                    }
                                }

                                if (y == person.Possition[0, 0] && person is Thieve thief)
                                {
                                    if (y == person.Possition[0, 0] && y == person2.Possition[0, 0] && x == person.Possition[0, 1] && x == person2.Possition[0, 1] && person2 is Citizen citizen)
                                    {
                                        //Logik om Medborgare och Tjuv hamnar på samma kordinater, så snor tjuven om det finns saker att sno
                                        if (citizen.inventory.Count > 0)
                                            thief.Interaction(thief, citizen);

                                        //Printar ut item som finns i tjuv
                                        //foreach (var item in thief.inventory)
                                        //{
                                        //    Console.WriteLine(item.Item);
                                        //}

                                        kont = true;
                                        check = true;
                                        NAMES = $"Namn: {person.Name} - {person2.Name}, Kordinat: X:{person.Possition[0, 0]} Y:{person.Possition[0, 1]} - X:{person2.Possition[0, 0]} Y:{person2.Possition[0, 1]}";
                                    }
                                    else if (y == person.Possition[0, 0] && y == person2.Possition[0, 0] && x == person.Possition[0, 1] && x == person2.Possition[0, 1] && person2 is Police)
                                    {
                                        // Behövs verkligen denna if-satsen? Kan ju skriva koden i polisen OM polisen hamnar på en tjuvs kordinater eller att en tjuv hamnar på polisens kordinater
                                        check = true;
                                    }
                                    else if (x == person.Possition[0, 1] && number2 < 1 && x != person2.Possition[0, 1] && person is not Citizen)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("T");
                                        Console.ResetColor();
                                        check = true;
                                    }
                                    number2++;
                                }
                                if (y == person.Possition[0, 0] && person is Police police)
                                {
                                    if (y == person.Possition[0, 0] && y == person2.Possition[0, 0] && y == person.Possition[0, 1] && y == person2.Possition[0, 1] && person2 is Citizen)
                                    {
                                        check = true;

                                    }
                                    else if (y == person.Possition[0, 0] && y == person2.Possition[0, 0] && x == person.Possition[0, 1] && x == person2.Possition[0, 1] && person2 is Thieve thief2)
                                    {
                                        check = true;
                                        if(thief2.inventory != null)
                                        {
                                            police.Interaction(police, thief2);
                                        }
                                    }
                                    else if (x == person.Possition[0, 1] && number3 < 1 && x != person2.Possition[0, 1] && person2 is not Citizen && person2 is not Thieve)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write("P");
                                        Console.ResetColor();
                                        check = true;
                                    }
                                    number3++;
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
            { Console.Write("#"); }

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
