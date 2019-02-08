using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_From_a_TextFile
{
    class ReadFromFile
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Panki\Desktop\PP2\Write_to_a_textfile\sobaka.txt");
            System.Console.WriteLine("Contents of sobaka.txt are \n{0}", text);
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Panki\Desktop\PP2\Write_to_a_textfile\lalalal.txt");
            System.Console.WriteLine("Contents of .txt are");
            foreach(string asd in lines)
            {
                Console.WriteLine("\t" + asd);// with indent
           
            }
            
        }
    }
}
