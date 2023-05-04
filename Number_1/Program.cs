namespace Lab_9;

public class Test
{
    public static void Main()
    {
        
        
        StreamReader reader = new StreamReader(@"/Users/valentin/Downloads/University/II семестр 2023/ООП/New_Laboratories/Lab_9/Number_1/Sportsmens.txt");
        string line;
        int index = 0;
        
        Normativ[] sportsmens = new Normativ[7];
        while ((line = reader.ReadLine()) != null)
        {
            string[] sport = line.Split(' ');
            int results = int.Parse(sport[2]);
            sportsmens[index] = new Normativ(sport[0], sport[1], results);
            index++;
        }
        reader.Close();

        sportsmens = Sort(sportsmens);
        
        StreamWriter writer = new StreamWriter(@"/Users/valentin/Downloads/University/II семестр 2023/ООП/New_Laboratories/Lab_9/Number_1/SortSportsmens.txt");
        writer.WriteLine("       Имя       Пол   Норматив  Результат");
        foreach (var sportsmen in sportsmens)
        {
            writer.WriteLine("{0,10} {1,9} {2,10}       {3}", sportsmen.name,  sportsmen.gender, sportsmen.norm, sportsmen.Result);
        }
        writer.Close();

        Console.ReadKey();
    }

    static Normativ[] Sort(Normativ[] categories)
    {
        for (int i = 0; i < categories.Length; i++)
        {
            for (int j = i + 1; j < categories.Length; j++)
            {
                if (categories[i].Result > categories[j].Result)
                {
                    (categories[i], categories[j]) = (categories[j], categories[i]);
                }
            }
        }
        return categories;
    }
}

class Sportsmen
{
    public string name;
    public string gender;
    public int Result;
    public Sportsmen(string name, string gender, int Result)
        {
            this.name = name;
            this.gender = gender;
            this.Result = Result;
        }
    }
    class Normativ : Sportsmen
    {
        public string norm;
        public Normativ(string name, string gender, int Result) : base(name, gender, Result)
        {
            this.name = name;
            this.gender = gender;
            this.Result = Result;
            if (gender == "male")
            {
                if (Result <= 5) norm = "сдал";
                else norm = "не сдал";
            }
            else
            {
                if (Result <= 7) norm = "сдала";
                else norm = "не сдала";
            }
        }
        public void Print()
        {
            Console.WriteLine($"{Result}       {norm}");
        }
    }
    