namespace ThievesAndPolice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Prison prison = new Prison();

            while (true)
            {
                Console.Clear();
                prison.MovePatter();
                Console.ReadKey();
            }

        //    int possitionX = 10;
        //    int possitionY = 20;


        //    int[,] array =
        //    {
        //        {possitionX, possitionY}
        //    };
        //    List<string> list = new List<string>();
        //    list.Add("Plånbok");
        //    list.Add("Väska");
        //    list.Add("Pengar");
        //    list.Add("Tampong");


        //    Citizen person = new Citizen("Christofer", 33, "Male", "Plånbok", false, false, array);


        //    Console.WriteLine($"\nName: {person.Name}");
        //    Console.WriteLine($"Age: {person.Age}");
        //    Console.WriteLine($"Gender: {person.Gender}");
        //    Console.WriteLine($"Items: {person.ItemName}");
        //    Console.WriteLine($"Is robbed: {person.IsRobbed}");
        //    Console.WriteLine($"Meets Police: {person.MeetPolice}");
        //    Console.WriteLine($"Possition X: {person.Possition[0, 0]}");
        //    Console.WriteLine($"Possition Y: {person.Possition[0, 1]}");
        }
    }
}
