using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace palindrome
{
    class ReadFromFile
    {
        static bool isPal(string s)
        {
            for (int i=0; i<s.Length; i++)
            {
                if (s[i] != s[s.Length - 1-i])
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string s = System.IO.File.ReadAllText(@"C:\Users\Panki\Desktop\PP2\Lab2\palornotpal.txt");
            if (isPal(s))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
