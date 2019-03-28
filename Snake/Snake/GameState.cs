using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{
    class GameState
    {
       public Worm w = new Worm('0');
      public  Food f = new Food('@');
       Wall b = new Wall('#');
        Timer timer = new Timer();
        Timer timer2 = new Timer();
        bool ok = true;
       


        public GameState()      
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }

        public void Run()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 50;
            timer.Start();
            if (ok)
            {
                f.Draw();
                b.Draw();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(10, 10);
                Console.WriteLine("Gameover");
            }
        }

            private void  Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            w.Clear();
            w.Move();
            w.Draw();
            CheckFood();
            chekWall();
        }

       
        void CheckFood()
        {
           if (w.CheckCollision(f.body[0]))
            {
                w.Eat(f.body[0]);
                f.Generate();
                f.Draw();
                w.Draw();
            }
        }
        void chekWall()
        {
            for(int i = 0; i < b.body.Count; i++)
            {
                if (w.CheckCollision(b.body[i]))
                {
                    ok = false;
                }
            }
        }
        void chekwithItSelf()
        {
            for (int i = 1; i < w.body.Count; i++)
            {
                if (w.CheckCollision(w.body[i]))
                {
                    ok = false;
                    break;
                }
            }
        }
        
        
        public void PressedKey(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    w.Dx = 0;
                    w.Dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                    w.Dx = 0;
                    w.Dy = 1;
                    break;
                case ConsoleKey.RightArrow:
                    w.Dx = 1;
                    w.Dy = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    w.Dx = -1;
                    w.Dy = 0;
                    break;
                case ConsoleKey.Spacebar:
                    timer.Enabled = !timer.Enabled;
                    break;
            }
         
        }
    }
}
