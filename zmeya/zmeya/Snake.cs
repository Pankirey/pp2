using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zmeya
{
    public class Snake : GameObject
    {
        public Snake(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color)
        {
        }

        public void Move(ConsoleKeyInfo keyInfo)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            if (keyInfo.Key == ConsoleKey.DownArrow)
                body[0].y++;
            if (keyInfo.Key == ConsoleKey.UpArrow)
                body[0].y--;
            if (keyInfo.Key == ConsoleKey.LeftArrow)
                body[0].x--;
            if (keyInfo.Key == ConsoleKey.RightArrow)
                body[0].x++;
        }

        public bool IsCollisionWithFood(Food food)
        {
            if (body[0].x == food.body[0].x && body[0].y == food.body[0].y)
                return true;
            return false;
        }

        public bool IsCollistionWithWall(Wall wall)
        {
            foreach (Point p in wall.body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;
            }
            return false;
        }

        public bool IsCollisionWithSnake()
        {
            for (int i = 1; i < body.Count; i++)
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            return false;
        }
    }
}