using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class ReadFromFile
    {
        static bool isPrime(int x)
        {
            if (x < 2)
                return false;
            for (int i=2; i<=Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Panki\Desktop\pp22\Lab2\Task2\dd.txt");
            string[] tt = text.Split();
            int[] a = new int[tt.Length];
            int cnt = 0;
            for (int i=0;i<tt.Length; i++)
            {
                int x = int.Parse(tt[i]);
                if (isPrime(x))
                {
                    a[cnt++] = x;
                }
            }
           
       for(int i=0; i<cnt; i++)
            {

                using (System.IO.StreamWriter file =
               new System.IO.StreamWriter(@"C:\Users\Panki\Desktop\pp22\Lab2\Task2\ff.txt", true))
                {
                    file.Write(a[i].ToString()+" ");
                }
            }
           

        }
    }
}
