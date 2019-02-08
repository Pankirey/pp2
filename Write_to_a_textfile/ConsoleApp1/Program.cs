using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class WriteTextFile
    {
        static void Main(string[] args)
        { string text = "I will show you the way, my brother";
            string[] lines = { "First Line", "Second Line", "Third Line" };
            System.IO.File.WriteAllLines(@"C:\Users\Panki\Desktop\PP2\Write_to_a_textfile\sobaka.txt", lines);
            System.IO.File.WriteAllText(@"C:\Users\Panki\Desktop\PP2\Write_to_a_textfile\asd.txt", text);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Panki\Desktop\PP2\Write_to_a_textfile\sobaka2.txt"))
                foreach( string line in lines)
                {
                    if (!line.Contains("First"))
                    {
                        file.WriteLine(line);
                    }
                }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Panki\Desktop\PP2\Write_to_a_textfile\sobaka2.txt", true))
                file.WriteLine("Fourth Line");
            int n=int.Parse(Console.ReadLine());
            string[] linessss = new string[n];
            for (int i=0; i<linessss.Length; i++)
            {
                linessss[i] = Console.ReadLine();
            }
                System.IO.File.WriteAllLines(@"C:\Users\Panki\Desktop\PP2\Write_to_a_textfile\lalalal.txt", linessss);
     
  

        }
    }
}
