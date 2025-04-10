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

    public List<Item> PoliceInventory = new List<Item>();

    public bool Arrest { get; set; }

    public bool IsArresting { get; set; }
    public override string Activity(string input)
    {
        List<string> words = new List<string>()
        {
            "och gråter en stor pöl                 ",
            "och spottar polisen i ansiktet         ",
            "och blir förbannad och försöker springa"
        };

        int random = Random.Shared.Next(0, words.Count);

       return $"Police: {Name} arresterar tjuven {input} blir arresterad {words[random]}";
        
    }

}
