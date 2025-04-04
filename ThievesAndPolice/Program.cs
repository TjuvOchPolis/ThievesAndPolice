using System;
using System.Collections;
using System.Globalization;
using System.Xml;

namespace ThievesAndPolice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();

            List<Item> items = data.AddItems();
            List<Person> people = data.AddPeople();
            List<Thieve> prison = new List<Thieve>();

            //Sätter en startposition för samtliga i people-listan
            foreach (Person person in people)
            {
                person.StartPosition();
                if (person is Citizen citizen)
                    person.Items = items;
            }

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
                                    thief.IsArrested = true;
                                    police.IsArresting = true;

                                    Console.WriteLine(police.Activity());
                                    Console.WriteLine(thief.Activity());

                                    prison.Add(thief);
                                    people.Remove(thief);
                                }
                            }
                            else if (people[j] is Citizen citizen)
                            {
                                if (citizen.PositionX == police.PositionX &&
                                   citizen.PositionY == police.PositionY)
                                {
                                    citizen.MeetPolice = true;
                                    Console.WriteLine(citizen.Activity());
                                    police.MeetCitizen = true;
                                    Console.WriteLine(police.Activity()); ;
                                }
                            }
                        }
                    }
                }
                //Bygger staden
                char[,] city = data.BuildCity();
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
                char[,] prison1 = data.BuildPrison();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        char symbol = prison1[i, j];
                        foreach (Person person in prison)
                        {
                            if (person.PositionX == i && person.PositionY == j && person is Thieve)
                                symbol = 'T';
                        }

                        if (symbol == 'T')
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write(symbol);
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }

                //Delar upp move pattern till metoderna för att underlätta läsning
                //Move pattern för invånare i  city
                foreach (Person person in people)
                    person.PersonMoveInCity();

                //Move pattern för tjuvarna i prison
                foreach (Thieve thief in prison)
                    thief.MoveInJail();

                Console.ReadKey();
            }
        }

        //static void SetCursor(string cursor)
        //{
        //    Console.SetCursorPosition(65, Console.CursorLeft);
        //    Console.WriteLine(cursor);
        //}
    }
}