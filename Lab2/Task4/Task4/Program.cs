
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            string q = @"C:\Users\Panki\Desktop\pp22\Lab2\Task4\q.txt";    //  Пути для создания 
            string w = @"C:\Users\Panki\Desktop\pp22\Lab2\Task4\w.txt";    //     файлов
            string asd = "The world is mine!!!";
            StreamWriter dd = new StreamWriter(q);
            dd.Write(asd);
            dd.Close();
            File.Copy(q, w);   //  Копируем  в новый файл
            File.Delete(q);   //  Удаляем первый файл
        }
    }
}