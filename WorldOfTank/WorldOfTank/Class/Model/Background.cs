using System.Collections.Generic;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    public class Background : StaticObject
    {
        public Background(Image image)
            : base(image, TypeObject.Background)
        {
        }

        public override TypeResult NextFrame(List<ObjectGame> objects)
        {
            return TypeResult.Nothing;
        }
    }
}
