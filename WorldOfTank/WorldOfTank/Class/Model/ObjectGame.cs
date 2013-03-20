using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    abstract class ObjectGame
    {
        public Image Image;
        public Size Size;
        public Position Position;
        public TypeObject Type;
        public PictureBox Picture;

        public ObjectGame(Image Image, TypeObject Type)
        {
            this.Image = Image;
            this.Size = new Size(1, 1);
            this.Position = new Position(0, 0);
            this.Type = Type;

            this.Picture = new PictureBox();
            this.Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Picture.BackColor = Color.Transparent;
        }

        public bool IsCollided(ObjectGame obj)
        {
            if ((this.Position.X + this.Size.Width <= obj.Position.X) ||
                (obj.Position.X + obj.Size.Width <= this.Position.X) ||
                (this.Position.Y + this.Size.Height <= obj.Position.Y) ||
                (obj.Position.Y + obj.Size.Height <= this.Position.Y))
                return false;
            return true;
        }
    }
}
