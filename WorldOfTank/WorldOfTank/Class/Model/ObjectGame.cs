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
            int this_x1 = (int)this.Position.X;
            int this_x2 = this_x1 + this.Size.Width;
            int this_y1 = (int)this.Position.Y;
            int this_y2 = this_y1 + this.Size.Height;

            int obj_x1 = (int)obj.Position.X;
            int obj_x2 = obj_x1 + obj.Size.Width;
            int obj_y1 = (int)obj.Position.Y;
            int obj_y2 = obj_y1 + obj.Size.Height;

            if (((this_x1 <= obj_x1 && obj_x1 < this_x2) || (obj_x1 <= this_x1 && this_x1 < obj_x2)) &&
                ((this_y1 <= obj_y1 && obj_y1 < this_y2) || (obj_y1 <= this_y1 && this_y1 < obj_y2)))
                return true;
            return false;
        }
    }
}
