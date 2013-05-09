using System;
using WorldOfTank.Class.Model;

namespace WorldOfTank.Class.Components
{
    public static class GlobalVariableGame
    {
        public const float EPSILON = 1e-6f;

        public static float FramePerSecond = 40;
        public static float BonusScoreAlive = 0.025f;   // each frame
        public static float BonusScoreKiller = 10;
        public static float CostPerAttack = 1;          // score
        public static float TimeDelayAttack = 4;        // frames

        public static float TimeRemaining;
        public static int NumberTank;

        public static string PrintTankInformation(Tank tank)
        {
            return String.Format("  Damage: {0} - {1}\n  Armor: {2}\n  Heal: {3}\n  Movement speed: {4}\n  Rotation speed: {5}\n  Attack speed: {6}\n  Rada range: {7}\n  Rada angle: {8}",
                tank.DamageMin, tank.DamageMax, tank.Armor, tank.HealMax, tank.SpeedMove, tank.SpeedRotate, tank.SpeedFire, tank.RadaRange, tank.RadaAngle);
        }
    }
}
