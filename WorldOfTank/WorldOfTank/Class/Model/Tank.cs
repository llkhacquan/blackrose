using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    class Tank : ObjectGame
    {
        public Direction direction { set; get; }
        public int speed { set; get; }
        public int damage { set; get; }
        public int heal { set; get; }

        public Tank()
        {
        }

        public void turnLeft() {
            if (direction == Direction.North) direction = Direction.West;
            else if (direction == Direction.West) direction = Direction.South;
            else if (direction == Direction.South) direction = Direction.East;
            else direction = Direction.North;
        }

        public void turnRight()
        {
            if (direction == Direction.North) direction = Direction.East;
            else if (direction == Direction.East) direction = Direction.South;
            else if (direction == Direction.South) direction = Direction.West;
            else direction = Direction.North;
        }

        public void moveUp()
        {
            if (direction == Direction.North) position.y -= speed;
            else if (direction == Direction.South) position.y += speed;
            else if (direction == Direction.East) position.x += speed;
            else position.x -= speed;
        }

        public void moveDown()
        {
            if (direction == Direction.North) position.y += speed;
            else if (direction == Direction.South) position.y -= speed;
            else if (direction == Direction.East) position.x -= speed;
            else position.x += speed;
        }

        public void attack()
        {
        }

        public void actionNormal()
        {
        }
    }
}
