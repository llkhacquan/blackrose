using System;
using System.Collections.Generic;
using System.Drawing;
using WorldOfTank.Class.Components;
using WorldOfTank.Properties;

namespace WorldOfTank.Class.Model
{
    /// <summary>
    /// This class handles the BattleField object
    /// </summary>
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
        public BattleField(Size size)
        {
            Objects = new List<ObjectGame>();
            Size = size;
        }

        /// <summary>
        ///     Setup game
        /// </summary>
        public void SetupGame(List<Tank> listTanks)
        {
            // Setup walls for BattleField
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

            // Put tanks in the BattleField
            var random = new Random();
            foreach (Tank rootTank in listTanks)
            {
                Tank tank = rootTank.Clone();
                Objects.Add(tank);
                tank.Direction = random.Next(360);
                do
                {
                    tank.Position.X = random.Next(Size.Width);
                    tank.Position.Y = random.Next(Size.Height);
                } while (tank.IsInvalidPosition(Objects));
            }
        }

        /// <summary>
        ///     Execute some change in a frame in battlefield
        /// </summary>
        /// <returns>Result of that frame</returns>
        public void NextFrame()
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].NextFrame(Objects) == TypeResult.BeDestroyed)
                {
                    if (Objects[i].Type == TypeObject.Tank) GlobalVariableGame.NumberTank--;
                    Objects.RemoveAt(i--);
                }
            }
        }
    }
}
