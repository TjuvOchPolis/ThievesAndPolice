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
                new Citizen("Johannes", 24, items, "male", false, false),
                new Police("Markus", 48, items, "male", false),
                new Thieve("Kristoffer", 32, items, "male", false),
                new Citizen("Thomas", 12, items, "male", false, false),
                new Police("Linda", 49, items, "male", false),
                new Thieve ("Oskar", 56, items, "male", false),
                new Citizen("Magnus", 24, items, "male", false, false),
                new Police("Wilma", 48, items, "male", false),
                new Thieve("Christoffer", 32, items, "male", false),
                new Citizen("Annie", 12, items, "male", false, false),
                new Police("Torbjörn", 49, items, "male", false),
                new Thieve ("Elin", 56, items, "male", false),
                new Citizen("Ragnar", 24, items, "male", false, false),
                new Police("Bertil", 48, items, "male", false),
                new Thieve("Chris", 32, items, "male", false),
                new Citizen("Seth", 12, items, "male", false, false),
                new Police("Tim", 49, items, "male", false),
                new Thieve ("Måns", 56, items, "male", false),
            };


            //Sätter en startposition för samtliga i people-listan
            foreach (Person person in people)
                person.StartPosition();

            while (true)
            {
                Console.Clear();

                List<string> messages = new List<string>();

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


                                    police.IsArresting = true;
                                    thief.IsArrested = true;

                                    thief.PositionX = rnd.Next(1, 9); // Prison är 10 x 10
                                    thief.PositionY = rnd.Next(1, 9);

                                    string policeMessage = police.Activity();
                                    if (!string.IsNullOrEmpty(policeMessage))
                                    {
                                        messages.Add(policeMessage);
                                    }
                                    thief.Activity();

                                }
                            }
                            else if (people[j] is Citizen citizen)
                            {
                                if(citizen.PositionX == police.PositionX &&
                                   citizen.PositionY == police.PositionY)
                                {
                                    police.MeetCitizen = true;
                                    string policeMessage = police.Activity();
                                    if (!string.IsNullOrEmpty(policeMessage))
                                    {
                                        messages.Add(policeMessage);
                                    }

                                    citizen.MeetPolice = true;
                                    string citizenMessage = citizen.Activity();
                                    if (!string.IsNullOrEmpty(citizenMessage))
                                    {
                                        messages.Add(citizenMessage);
                                    }
                                    police.Activity();
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
                            if (person is Thieve thief && thief.IsArrested)
                                continue; // Om person i listan people är en thief så skippar den kod för denna personen och hoppar till nästa
                                

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

                    if (i < messages.Count)
                    {
                        Console.Write("     " + messages[i]);
                    }
                    Console.WriteLine();

                }

                Console.ForegroundColor= ConsoleColor.DarkRed;
                Console.WriteLine("==========");
                Console.WriteLine("==Prison==");
                Console.WriteLine("==========");
                Console.ForegroundColor = ConsoleColor.White;

                //Fängelse målas
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        char symbol = prison1[i, j];

                        foreach (Person person in people)
                        {
                            if (person is Thieve thief && thief.IsArrested &&
                                thief.PositionX == i && thief.PositionY == j)
                            {
                                symbol = 'T';
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                        }
                        Console.Write(symbol);
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }

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
    }
}