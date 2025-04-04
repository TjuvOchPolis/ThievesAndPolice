using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Thieve : Person
{
    public Thieve(string name, int age, string gender, bool arrested) : base(name, age, gender)
    {
        IsArrested = arrested;
    }
    public bool IsArrested { get; set; }
    public bool IsRobbing { get; set; }

    public override string Activity()
    {
        if (IsArrested)
        {
            PositionX = Random.Shared.Next(0, 10);
            PositionY = Random.Shared.Next(0, 10);
            if (Items != null)
            {
                IsArrested = false;
                Items.Clear();

                return $"{Name} has been arrested!";
            }
        }
        return base.Activity();
    }

    public void MoveInJail()
    {
        int nextMove = Random.Shared.Next(1, 8 + 1);
        switch (nextMove)
        {
            case 1: PositionX += 1; break; //Höger
            case 2: PositionX -= 1; break; // Vänster
            case 3: PositionY += 1; break; // Ner
            case 4: PositionY -= 1; break; // Upp
            case 5: PositionX += 1; PositionY += 1; break; // Diagonalt höger ner 
            case 6: PositionX += 1; PositionY -= 1; break; // Diagonalt höger upp
            case 7: PositionX -= 1; PositionY += 1; break; // Diagonalt vänster ner
            case 8: PositionX -= 1; PositionY -= 1; break; // Diagonalt vänster upp
        }

        //Math.Clamp sätter ett min och max värde för PositionX och PositionY så slipper man alla if klausuler
        PositionX = Math.Clamp(PositionX, 2, 9);
        PositionY = Math.Clamp(PositionY, 2, 9);
    }
}
