using System;
using System.Collections;

namespace ThievesAndPolice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            City city1 = new City();
            Prison prison = new Prison();
            Random rnd = new Random();
            int[,] thiefArray = new int[20, 2];
            int[,] policeArray = new int[20, 2];
            int[,] citizenArray = new int[20, 2];

            char[,] city = city1.BuildCity();
            char[,] prison1 = prison.BuildPrison();

            List<Inventory> items = new List<Inventory>()
            {
                new Inventory ("Wallet"),
                new Inventory ("Phone"),
                new Inventory ("Bag"),
            };

            List<Person> people = new List<Person>()
            {
                new Citizen("Hej", 24, items, "male", false, false),
                new Police("ADA", 48, items, "male", false),
                new Thieve("Kristoffer", 32, items, "male", false),
                new Citizen("KDA", 12, items, "male", false, false),
                new Police("Poaes", 49, items, "male", false),
                new Thieve ("Kristoffer", 56, items, "male", false),
                new Citizen("Hej", 24, items, "male", false, false),
                new Police("ADA", 48, items, "male", false),
                new Thieve("Christoffer", 32, items, "male", false),
                new Citizen("KDA", 12, items, "male", false, false),
                new Police("Poaes", 49, items, "male", false),
                new Thieve ("Christoffer", 56, items, "male", false),
                new Citizen("Hej", 24, items, "male", false, false),
                new Police("ADA", 48, items, "male", false),
                new Thieve("Christoffer", 32, items, "male", false),
                new Citizen("KDA", 12, items, "male", false, false),
                new Police("Poaes", 49, items, "male", false),
                new Thieve ("Christoffer", 56, items, "male", false),
            };

            //Sätter en startposition för samtliga i people-listan
            foreach (Person person in people)
                person.StartPosition();

            while (true)
            {
                Console.Clear();

                for (int i = 0; i < people.Count; i++)
                {
                    //Om people[index i] är en polis så händer följande: 
                    if (people[i] is Police police)
                    {
                        //Går igenom alla personer i listan [people]
                        for (int j = 0; j < people.Count; j++)
                        {
                            //Om people[index j] är en thieve och inte arrested händer följande: 
                            if (people[j] is Thieve thief && !thief.IsArrested)
                            {
                                //Om police och thief har samma x och y position händer följande: 
                                if (police.PositionX == thief.PositionX &&
                                    police.PositionY == thief.PositionY)
                                {
                                    //Thief blir arrested.
                                    SetCursor(police.Activity());
                                    SetCursor(thief.Activity());

                                }
                            }
                            else if (people[j] is Citizen citizen)
                            {
                                if(citizen.PositionX == police.PositionX &&
                                   citizen.PositionY == police.PositionY)
                                {

                                    citizen.MeetPolice = true;
                                    police.MeetCitizen = true;
                                    SetCursor(police.Activity());
                                    SetCursor(citizen.Activity());
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i < 25; i++) // går igenom all 25 rader i city[,]
                {
                    for (int j = 0; j < 50; j++) //går igenom alla 50 rader i city[,]
                    {
                        //Symbol representerar antingen chars i arrayen i City-Klassen om inte person är Citizen, Police eller Thief
                        char symbol = city[i, j];

                        foreach (Person person in people)
                        {
                            if (person.PositionX == i && person.PositionY == j && person is Citizen)
                                symbol = 'C';
                            else if (person.PositionX == i && person.PositionY == j && person is Police)
                                symbol = 'P';
                            else if (person.PositionX == i && person.PositionY == j && person is Thieve)
                                symbol = 'T';

                        }


                        //Ändrar färg på symbolen för invånare
                        if (symbol == 'C')
                            Console.ForegroundColor = ConsoleColor.Green;
                        else if (symbol == 'P')
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else if (symbol == 'T')
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write(symbol);

                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }



                //Fängelse målas
                /*for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(prison1[i, j]);
                    }
                    Console.WriteLine();
                }*/

                foreach (var person in people)
                {
                    //Förenklad switch. Gick att sätta allt på en linje
                    //Efter person är "målad" på konsollen kan person bara gå ett steg i taget
                    int nextMove = rnd.Next(1, 8 + 1);
                    switch (nextMove)
                    {
                        case 1: person.PositionX += 1; break; //Höger
                        case 2: person.PositionX -= 1; break; // Vänster
                        case 3: person.PositionY += 1; break; // Ner
                        case 4: person.PositionY -= 1; break; // Upp
                        case 5: person.PositionX += 1; person.PositionY += 1; break; // Diagonalt höger ner 
                        case 6: person.PositionX += 1; person.PositionY -= 1; break; // Diagonalt höger upp
                        case 7: person.PositionX -= 1; person.PositionY += 1; break; // Diagonalt vänster ner
                        case 8: person.PositionX -= 1; person.PositionY -= 1; break; // Diagonalt vänster upp
                    }

                    //Math.Clamp sätter ett min och max värde för PositionX och PositionY så slipper man alla if klausuler
                    person.PositionX = Math.Clamp(person.PositionX, 1, 23);
                    person.PositionY = Math.Clamp(person.PositionY, 1, 48);
                }

                Console.ReadKey();

            }
        }

        static void SetCursor(string cursor)
        {
            Console.SetCursorPosition(65, Console.CursorLeft);
            Console.WriteLine(cursor);
        }
    }
}