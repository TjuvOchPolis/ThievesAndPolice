using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThievesAndPolice;
internal class Police : Person
{
    public Police(string name, int[,] pos) : base(name, pos)
    {
        Name = name;
    }

    public Stack<Item> PoliceInventory = new Stack<Item>();

    public bool Arrest { get; set; }

    public bool IsArresting { get; set; }
    public override string Activity(string input)
    {
        List<string> words = new List<string>()
        {
            "och gråter en stor pöl                 ",
            "och spottar polisen i ansiktet         ",
            "och försöker springa                   "
        };

        int random = Random.Shared.Next(0, words.Count);

       return $"Police: {Name} arresterar tjuven {input}. {input} blir förbannad {words[random]}";
        
    }

}
