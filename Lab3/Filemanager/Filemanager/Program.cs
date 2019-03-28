using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filemanager
{
    enum FSIMode
    {
        DirectoryInfo = 1,
        File = 2
    }

    class Layer
    {
        public FileSystemInfo[] Content
        {
            get;
            set;
        }
        int selected;
        public int SelectedIndex
        {
            get
            {
                return selected;
            }
            set
            {
                if (value < 0)
                {
                    selected = Content.Length - 1;
                }
                else if (value >= Content.Length)
                {
                    selected = 0;
                }
                else selected = value;
            }
        }
    

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < Content.Length; ++i)
            {

                if (Content[i].GetType() == typeof(DirectoryInfo))
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (i == SelectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                   
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(Content[i].Name);
            }

        }
        
    }




    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Panki\Desktop\for file manager");
            Layer l = new Layer
            {
                Content = dir.GetFileSystemInfos(),
                SelectedIndex = 0
            };

            FSIMode curMode = FSIMode.DirectoryInfo;

            Stack<Layer> history = new Stack<Layer>();
            history.Push(l);

            bool esc = false;
            while (!esc)
            {
                if (curMode ==FSIMode.DirectoryInfo)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedIndex++;
                        break;
                    case ConsoleKey.Enter:
                        int index = history.Peek().SelectedIndex;
                        int a = history.Peek().Content.Length; 
                        int b = history.Peek().Content.Length;
                      
                        FileSystemInfo fsi = history.Peek().Content[index];
                        if (fsi.GetType() == typeof(DirectoryInfo))
                        {
                            curMode = FSIMode.DirectoryInfo;
                        
                            DirectoryInfo d = fsi as DirectoryInfo;
                            history.Push(new Layer
                            {
                                Content = d.GetFileSystemInfos(),
                                SelectedIndex = 0
                            });
                        }
                        else
                        {
                            curMode = FSIMode.File;
                            using (FileStream fs = new FileStream(fsi.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (curMode == FSIMode.DirectoryInfo)
                        {
                            history.Pop();
                        }
                        else
                        {
                            curMode = FSIMode.DirectoryInfo;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Escape:
                        esc = true;
                        break;
                   
                     case ConsoleKey.D:
                         int g = history.Peek().SelectedIndex;
                         FileSystemInfo fg = history.Peek().Content[g];
                         fg.Delete();

                         if (history.Count == 0)
                         {
                             history.Peek();

                             if (curMode == FSIMode.DirectoryInfo)
                             {
                                 history.Peek().Draw();
                             }
                         }
                         else if (history.Count >0)
                         {
                             history.Pop();
                             int jk = history.Peek().SelectedIndex;
                             FileSystemInfo nb = history.Peek().Content[jk];
                             DirectoryInfo df = nb as DirectoryInfo;
                             history.Push(new Layer
                             {
                                 Content = df.GetFileSystemInfos(),
                                 SelectedIndex = 0
                             });
                         }
                         break;
                    case ConsoleKey.R:
                        int q = history.Peek().SelectedIndex;
                        FileSystemInfo cv = history.Peek().Content[q];
                        Console.Clear();
                     
                        Console.Write("Переименовать в: ");
                        string name = Console.ReadLine();
                        if (cv.GetType() ==typeof(DirectoryInfo))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Directory.Move(cv.FullName, Path.GetDirectoryName(cv.FullName) + "/" + name);
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.BackgroundColor = ConsoleColor.Black;
                            File.Copy(cv.FullName, Path.GetDirectoryName(cv.FullName) + "/" + name + ".txt");
                            File.Delete(cv.FullName);
                            history.Pop();
                            int lk = history.Peek().SelectedIndex;
                            FileSystemInfo uj = history.Peek().Content[lk];
                            DirectoryInfo hn = uj as DirectoryInfo;
                            history.Push(new Layer
                            {
                                Content = hn.GetFileSystemInfos(),
                                SelectedIndex = 0
                            });
                        }


                        break;
                            

                }
                }
                    
            }
      
        }
    }

