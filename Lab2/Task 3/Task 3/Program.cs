using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class FileSysInfo
    {
        static void Main(string[] args)
        {
            System.IO.DriveInfo di = new System.IO.DriveInfo(@"C:\Users\Panki\Desktop\pp22");
            System.IO.DirectoryInfo dirInfo = di.RootDirectory;
            System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.*");

            System.IO.DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");

            foreach (System.IO.DirectoryInfo d in dirInfos)
            {
                Console.WriteLine(d.Name);
            }

        }
    }
}