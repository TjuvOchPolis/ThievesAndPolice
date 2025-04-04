using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Data
{
    public List<Person> AddPeople()
    {
        List<Person> people = new List<Person>()
            {
                new Citizen("Andersson", 24, "male", false, false),
                new Police("Pettersson", 48, "male", false),
                new Thieve("Axelsson", 32, "male", false),
                new Citizen("Lindqvist", 24, "male", false, false),
                new Police("Johansson", 48, "male", false),
                new Thieve("Svensson", 32, "male", false),
                new Citizen("Eriksson", 24, "male", false, false),
                new Police("Bergström", 48, "male", false),
                new Thieve("Nilsson", 32, "male", false),
                new Citizen("Lundgren", 24, "male", false, false),
                new Police("Holm", 48, "male", false),
                new Thieve("Carlsson", 32, "male", false),
                new Citizen("Öberg", 24, "male", false, false),
                new Police("Larsson", 48, "male", false),
                new Thieve("Ström", 32, "male", false),
                new Citizen("Dahl", 24, "male", false, false),
                new Police("Nyberg", 48, "male", false),
                new Thieve("Mårtensson", 32, "male", false),

            };
        return people;
    }

    public List<Item> AddItems()
    {
        List<Item> items = new List<Item>()
            {
                new Item ("Wallet"),
                new Item ("Phone"),
                new Item ("Bag"),
            };
        return items;
    }


    //Bygger stad och Fängelse
    public char[,] BuildPrison()
    {
        int width = 10;
        int height = 10;
        char[,] prison = new char[height, width];

        //Samma metod som BuildCity fast för mindre för fängelset
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                    prison[i, j] = '*';
                else
                    prison[i, j] = ' ';
            }
        }
        return prison;
    }

    public char[,] BuildCity()
    {
        int width = 50;
        int height = 25;
        char[,] box = new char[height, width];

        //Bygger staden och sätter kanterna till '*'
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                    box[i, j] = '*';
                else
                    box[i, j] = ' ';
            }
        }
        return box;
    }
}
