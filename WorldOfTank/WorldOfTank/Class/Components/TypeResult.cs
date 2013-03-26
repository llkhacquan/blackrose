using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldOfTank.Class.Components
{
    enum TypeResult
    {
        Nothing,
        BeDestroyed,
        GameOver,
        Normal,
        CannotMoveForward,
        CannotMoveBackward,
        Detected,
        BeAttacked,
    }
}
