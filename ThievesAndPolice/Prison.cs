using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Prison
{
    static Random random = new Random();

    static int possitionX = random.Next(1, 49);
    static int possitionY = random.Next(0, 23);
    static int possitionThiefX = random.Next(1, 49);
    static int possitionThiefY = random.Next(0, 23);
    static int possitionPoliceX = random.Next(1, 49);
    static int possitionPoliceY = random.Next(0, 23);


    static int[,] array()
    {
        return new int[,]{
            { RandomX(), RandomY() }
        };
    }
    static int RandomX()
    {
        // Returnerar ett random nummer mellan 1 och 48
        return random.Next(1, 49);
    }
    static int RandomY()
    {
        // Returnerar ett random nummer mellan 0 och 22
        return random.Next(0, 23);
    }

    Citizen person = new Citizen("Christofer", 33, "Male", "Plånbok", false, false, array());    // DENNA FÅR SAMMA POSSITION SOM PERSON 2
    Citizen person2 = new Citizen("Koffe", 3, "Male", "Väska", false, false, array());           // DENNA FÅR SAMMA POSSITION SOM PERSON 1

    public void MovePatter()
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

        int posX = Possition("X", possitionThiefX); //tjuv
        int posY = Possition("Y", possitionThiefY);
        possitionThiefX = posX;
        possitionThiefY = posY;
        int pX = Possition("X", possitionPoliceX); // Polis
        int pY = Possition("Y", possitionPoliceY);
        possitionPoliceX = pX;
        possitionPoliceY = pY;

        int movX = 0;
        int movY = 0;

        if (moveX == -1)
            movX = possitionX - 1;
        else if (moveX == 1)
            movX = possitionX + 1;
        else
            movX = possitionX;

        if (moveY == -1)
            movY = possitionY - 1;
        else if (moveY == 1)
            movY = possitionY + 1;
        else
            movY = possitionY;


        if (movX == 0)
            movX = 1;
        else if (movX == 49)
            movX = 48;

        if (movY == 0)
            movY = 1;
        else if (movY == 23)
            movY = 22;

        possitionX = movX;
        possitionY = movY;

        array()[0, 0] = movX;
        array()[0, 1] = movY;


        Console.WriteLine($"Medborgare: X: {possitionX}  Y: {possitionY}");
        Console.WriteLine($"TJUV: X: {possitionThiefX}  Y: {possitionThiefY}");
        Console.WriteLine($"Polis: X: {pX}  Y:{pY}");


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
                    bool check = false;
                    if (i == person.Possition[0, 0])
                    {
                        if (j == person.Possition[0, 1])
                        {
                            Console.Write("C"); // Logik för att printa ut Polis, Tjuv, Medborgare
                            check = true;
                        }
                    }

                    if (i == posX && i != person.Possition[0, 0])
                    {
                        if (i == posX && i == person.Possition[0, 0])
                            check = false;
                        else if (i == pX && j == pY && i == posX && j == posY)
                        {

                        }
                        else if (j == posY)
                        {
                            Console.Write("T");
                            check = true;
                        }
                    }

                    if (i == pX)
                    {
                        if (i == pX && i == person.Possition[0, 0] && j == pY && j == person.Possition[0, 1])
                        {                           
                           
                        }
                        else if(i == pX && j == pY && i == posX && j == posY)
                        {
                            Console.WriteLine("TJUV TILL FÄNGELSE"); // här kommer logit för när en tjuv blir tagen
                        }
                        else if (j == pY)
                        {
                            Console.Write("P");
                            check = true;
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

    public int Possition(string angle, int number)
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
