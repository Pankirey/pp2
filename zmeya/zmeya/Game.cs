using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace zmeya

{
    public class Game
    {
        public Snake snake;
        public Food food;
        public Wall wall;

        bool isAlive;
        List<GameObject> g_objects;
        public Game()
        {
            isAlive = true;
            snake = new Snake(10, 10, '*', ConsoleColor.White);
            food = new Food(0, 0, 'o', ConsoleColor.Cyan);
            food.Generate();
            wall = new Wall('#', ConsoleColor.Yellow);
            wall.LoadLevel();

            g_objects = new List<GameObject>();
            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);

            Console.CursorVisible = false;
        }

        public void Start()
        {
            //int k = 0;
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            while (keyInfo.Key != ConsoleKey.Escape && isAlive)
            {
                snake.Move(keyInfo);
                Draw();
                keyInfo = Console.ReadKey();
                //k++;
                //if (k % 10 == 0)
                //{
                //    snake.body.Add(new Point(0, 0));
                //}
                if (snake.IsCollisionWithFood(food))
                {
                    snake.body.Add(new Point(0, 0));
                    food.Generate();
                    if (snake.body.Count % 3 == 0)
                        wall.NextLevel();

                }
                if (snake.IsCollistionWithWall(wall))
                    isAlive = false;
            }
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.Write("GAME OVER");
        }
        public void Draw()
        {
            Console.Clear();
            foreach (GameObject g in g_objects)
            {
                g.Draw();
            }
            //Console.SetCursorPosition(10, 10);
            //Console.WriteLine("Size of Snake " + snake.body.Count);
            //for (int i = 0; i < snake.body.Count; i++)
            //Console.WriteLine(snake.body[i].x + " " + snake.body[i].y);
        }
    }
}