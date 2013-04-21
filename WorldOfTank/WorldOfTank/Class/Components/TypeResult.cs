using System;
using System.Collections.Generic;
using System.Linq;

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
