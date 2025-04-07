//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;
//using ThievesAndPolice;

//namespace ThievesAndPolice;
//internal class FileName
//{
//    void myMethod()
//    {
//foreach (Person person in persons)
//{
//    foreach (Person person2 in persons)
//    {
//        if (i == person.Possition[0, 0] && person is Citizen)
//        {
//            if (j == person.Possition[0, 1] && number1 < 1)
//            {
//                number1++;
//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.Write("C"); // Logik för att printa ut Medborgare
//                Console.ResetColor();
//                check = true;

//            }
//        }

//        if (i == person.Possition[0, 0] && person is Thieve)
//        {
//            if (i == person.Possition[0, 0] && i == person2.Possition[0, 0] && j == person.Possition[0, 1] && j == person2.Possition[0, 1] && person2 is Citizen)
//            {
//                //Logik om Medborgare och Tjuv hamnar på samma kordinater, så snor tjuven om det finns saker att sno

//                person.Interaction();
//                kont = true;
//                check = true;
//                NAMES = $"Namn: {person.Name} - {person2.Name}, Kordinat: X:{person.Possition[0, 0]} Y:{person.Possition[0, 1]} - X:{person2.Possition[0, 0]} Y:{person2.Possition[0, 1]}";
//            }
//            else if (i == person.Possition[0, 0] && i == person2.Possition[0, 0] && j == person.Possition[0, 1] && j == person2.Possition[0, 1] && person2 is Police)
//            {
//                check = true;
//            }
//            else if (j == person.Possition[0, 1] && number2 < 1 && j != person2.Possition[0, 1] && person is not Citizen)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.Write("T");
//                Console.ResetColor();
//                check = true;
//            }
//            number2++;
//        }
//        if (i == person.Possition[0, 0] && person is Police)
//        {
//            if (i == person.Possition[0, 0] && i == person2.Possition[0, 0] && j == person.Possition[0, 1] && j == person2.Possition[0, 1] && person2 is Citizen)
//            {
//                check = true;

//            }
//            else if (i == person.Possition[0, 0] && i == person2.Possition[0, 0] && j == person.Possition[0, 1] && j == person2.Possition[0, 1] && person2 is Thieve)
//            {
//                check = true;
//                Console.WriteLine("TJUV TILL FÄNGELSE"); // här kommer logit för när en tjuv blir tagen
//            }
//            else if (j == person.Possition[0, 1] && number3 < 1 && j != person2.Possition[0, 1] && person2 is not Citizen && person2 is not Thieve)
//            {
//                Console.ForegroundColor = ConsoleColor.Blue;
//                Console.Write("P");
//                Console.ResetColor();
//                check = true;
//            }
//            number3++;
//        }
//    }
//}















//using ThievesAndPolice;

//int kontroll = 0;
//for (int i = 0; i < persons.Count; i++)
//{
//    if (persons[i] is Citizen citizen)
//    {
//        if (citizen.inventory.Count > 0)
//        {

//        }


//    }
//    else if (persons[i] is Thieve thief)
//    {
//        //kontroll = 2;
//    }
//    else if (persons[i] is Police police)
//    {
//        //kontroll = 3;
//    }


//    //switch (kontroll)
//    //{
//    //    //Logik för Medborgare
//    //    case 1:
//    //        if(Citizen.Inventory)
//    //        break;

//    //    //Logik för Tjuv
//    //    case 2:

//    //        break;

//    //    //Logik för Polis
//    //    case 3:

//    //        break;
//    //}
//}
//        }
//    }
//}
