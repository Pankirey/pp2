﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i=0; i<=n; i++)
            {   if (i == 0)
                    continue;
                for (int j=0; j<i; j++)
                { 
                        
                    Console.Write("[*]");
                }
                Console.Write("\n");
            }
        }
    }
}
