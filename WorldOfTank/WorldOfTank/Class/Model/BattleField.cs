using System.Collections.Generic;
using System.Drawing;
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
        ///     Gets or sets background of this battlefield
        /// </summary>
        public Image Background;

        /// <summary>
        ///     Constructor
        /// </summary>
        public BattleField()
        {
            Objects = new List<ObjectGame>();
            Size = new Size(600, 600);
            Background = Resources.Grass_A;
        }

        /// <summary>
        ///     Setup game
        /// </summary>
        public void SetupGame()
        {
            Wall wall;
            for (int i = 0; i <= (Size.Width - 1) / (Resources.Wall_A.Width - 1); i++)
            {
                wall = new Wall(Resources.Wall_A);
                wall.Position.X = (wall.Image.Width - 1) * i + wall.Image.Width / 2;
                wall.Position.Y = wall.Image.Height / 2;
                Objects.Add(wall);

                wall = new Wall(Resources.Wall_A);
                wall.Position.X = (wall.Image.Width - 1) * i + wall.Image.Width / 2;
                wall.Position.Y = Size.Height - wall.Image.Height + wall.Image.Height / 2;
                Objects.Add(wall);
            }

            for (int i = 0; i <= (Size.Height - 1) / (Resources.Wall_B.Height - 1); i++)
            {
                wall = new Wall(Resources.Wall_B);
                wall.Position.X = wall.Image.Width / 2;
                wall.Position.Y = (wall.Image.Height - 1) * i + wall.Image.Height / 2;
                Objects.Add(wall);

                wall = new Wall(Resources.Wall_B);
                wall.Position.X = Size.Width - wall.Image.Width + wall.Image.Width / 2;
                wall.Position.Y = (wall.Image.Height - 1) * i + wall.Image.Height / 2;
                Objects.Add(wall);
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

            int tankCount = 0;
            foreach (ObjectGame obj in Objects)
                if (obj.Type == TypeObject.Tank) tankCount++;
            if (tankCount <= 1) return TypeResult.GameOver;
            return TypeResult.Nothing;
        }
    }
}
