using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] s = Console.ReadLine().Split();
            int[] a = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                int x = int.Parse(s[i]);
                a[i] = x;
            }
            int[] d = new int[s.Length * 2];
            for (int i = 0; i < a.Length; i++)
            {
                d[2*i] = a[i];
                d[2*i + 1] = a[i];

             
            }
            for (int i=0; i<d.Length; i++)
            {
                Console.Write(d[i] + " ");
            }
        }
    }
}
