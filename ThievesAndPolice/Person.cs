using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Person
{
    public Person(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }


    public string Name { get; set; }
    public int Age { get; set; }
    public List<Item> Items { get; set; }
    public string Gender { get; set; }
    public int PositionY { get; set; }
    public int PositionX { get; set; }

    public virtual string Activity()
    {
        return "Person möter annan person";
    }
    public void StartPosition()
    {
        Random rnd = new Random();
        int[,] position = new int[PositionX, PositionY];

        PositionX = rnd.Next(0, 50 + 1);
        PositionY = rnd.Next(0, 25 + 1);

        int decider = rnd.Next(1, 5);

        if (decider == 1)
            PositionX = 0;
        else if (decider == 2)
            PositionX = 49;
        else if (decider == 3)
            PositionY = 0;
        else if (decider == 4)
            PositionY = 24;
    }
    public virtual void PersonMoveInCity()
    {
        
            //Förenklad switch. Gick att sätta allt på en linje
            //Efter person är "målad" på konsollen kan person bara gå ett steg i taget
            int nextMove = Random.Shared.Next(1, 8 + 1);
            switch (nextMove)
            {
                case 1: PositionX += 1; break; //Höger
                case 2: PositionX -= 1; break; // Vänster
                case 3: PositionY += 1; break; // Ner
                case 4: PositionY -= 1; break; // Upp
                case 5:PositionX += 1; PositionY += 1; break; // Diagonalt höger ner 
                case 6: PositionX += 1; PositionY -= 1; break; // Diagonalt höger upp
                case 7: PositionX -= 1; PositionY += 1; break; // Diagonalt vänster ner
                case 8: PositionX -= 1; PositionY -= 1; break; // Diagonalt vänster upp
            }

            //Math.Clamp sätter ett min och max värde för PositionX och PositionY så slipper man alla if klausuler
            PositionX = Math.Clamp(PositionX, 1, 23);
            PositionY = Math.Clamp(PositionY, 1, 48);
    }
  
}
