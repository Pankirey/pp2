using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primenumber
{
    class Program
    {
        static bool isPrime(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] s = Console.ReadLine().Split(); //write all numbers in one line
            int[] a = new int[s.Length]; // array, where all converted in int numbers will be stored
            int cnt = 0;
            for (int i = 0; i < s.Length; i++)//observing the array of strings
            {
                int x = int.Parse(s[i]);// all numbers from array of strings are converting to int
                if (isPrime(x))
                {
                    a[cnt++] = x;// array is filling with prime numbers after checking
                }
            }
            Console.WriteLine(cnt);
            for (int i = 0; i < cnt; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
