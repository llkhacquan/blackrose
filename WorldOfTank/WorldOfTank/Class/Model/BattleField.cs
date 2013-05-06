using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WorldOfTank.Class.Components;
using WorldOfTank.Properties;

namespace WorldOfTank.Class.Model
{
    public class BattleField
    {
        /// <summary>
        ///     Objects are this battlefield
        /// </summary>
        public List<ObjectGame> Objects;

        /// <summary>
        ///     Gets or sets size of this battlefield
        /// </summary>
        public Size Size;

        /// <summary>
        ///     Constructor
        /// </summary>
        public BattleField()
        {
            Objects = new List<ObjectGame>();
            Size = new Size(600, 600);
        }

        /// <summary>
        ///     Setup game
        /// </summary>
        public void SetupGame(List<Tank> listTanks)
        {
            for (int i = 0; i <= (Size.Width - 1) / Resources.Grass_A.Width; i++)
                for (int j = 0; j <= (Size.Height - 1) / Resources.Grass_A.Height; j++)
                {
                    var background = new Background(Resources.Grass_A);
                    background.Position.X = background.Image.Width * i + background.Image.Width / 2;
                    background.Position.Y = background.Image.Height * j + background.Image.Height / 2;
                    Objects.Add(background);
                }

            Wall wall;
            for (int i = 0; i <= (Size.Width - 1) / (Resources.Wall_A.Width - 1); i++)
            {
                wall = new Wall(Resources.Wall_A);
                wall.Position.X = (wall.Image.Width - 1) * i + wall.Image.Width / 2;
                wall.Position.Y = 0.5f * wall.Image.Height;
                Objects.Add(wall);

                wall = new Wall(Resources.Wall_A);
                wall.Position.X = (wall.Image.Width - 1) * i + wall.Image.Width / 2;
                wall.Position.Y = Size.Height - wall.Image.Height + wall.Image.Height / 2;
                Objects.Add(wall);
            }

            for (int i = 0; i <= (Size.Height - 1) / (Resources.Wall_B.Height - 1); i++)
            {
                wall = new Wall(Resources.Wall_B);
                wall.Position.X = 0.5f * wall.Image.Width;
                wall.Position.Y = (wall.Image.Height - 1) * i + wall.Image.Height / 2;
                Objects.Add(wall);

                wall = new Wall(Resources.Wall_B);
                wall.Position.X = Size.Width - wall.Image.Width + wall.Image.Width / 2;
                wall.Position.Y = (wall.Image.Height - 1) * i + wall.Image.Height / 2;
                Objects.Add(wall);
            }

            var random = new Random();
            foreach (Tank tank in listTanks)
            {
                Objects.Add(tank);
                do
                {
                    tank.Position.X = random.Next(Size.Width);
                    tank.Position.Y = random.Next(Size.Height);
                } while (tank.IsInvalidPosition(Objects));
            }
        }

        /// <summary>
        ///     Execute some change in a frame in battefield
        /// </summary>
        /// <returns>Result of that frame</returns>
        public TypeResult NextFrame()
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].NextFrame(Objects) == TypeResult.BeDestroyed)
                    Objects.RemoveAt(i--);
            }
            return Objects.Count(obj => obj.Type == TypeObject.Tank) < 2 ? TypeResult.GameOver : TypeResult.Nothing;
        }
    }
}
