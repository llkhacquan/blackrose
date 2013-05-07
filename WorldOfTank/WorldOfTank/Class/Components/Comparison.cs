using System;
using WorldOfTank.Class.Model;

namespace WorldOfTank.Class.Components
{
    /// <summary>
    /// This class handles Comparison in Creating Brain Tool
    /// </summary>
    [Serializable]
    public class Comparison
    {
        public TypeParameter Parameter;
        public TypeOperator Operator;
        public float Value;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Comparison()
        {
            Parameter = TypeParameter.GetCurrentHeal;
            Operator = TypeOperator.LowerEqual;
            Value = 100;
        }

        /// <summary>
        /// The turn the result of the Comparison
        /// </summary>
        /// <param name="yourTank"></param>
        /// <param name="enemyTank"></param>
        /// <param name="enemyBullet"></param>
        /// <returns></returns>
        public bool GetResult(Tank yourTank, Tank enemyTank, Bullet enemyBullet)
        {
            float par = 0;
            switch (Parameter)
            {
                case TypeParameter.GetPositionX:
                    par = yourTank.Position.X;
                    break;
                case TypeParameter.GetPositionY:
                    par = yourTank.Position.Y;
                    break;
                case TypeParameter.GetDirection:
                    par = MathProcessor.CalDifferentAngle(yourTank.Direction, 0);
                    break;
                case TypeParameter.GetCurrentHeal:
                    par = yourTank.HealCur;
                    break;
                case TypeParameter.GetEnemyDistance:
                    par = MathProcessor.CalDistance(yourTank.Position, enemyTank.Position);
                    break;
                case TypeParameter.GetEnemyDifferentAngle:
                    par = MathProcessor.CalDifferentAngle(yourTank.Direction, MathProcessor.CalPointAngle(yourTank.Position, enemyTank.Position));
                    break;
                case TypeParameter.GetEnemyCurrentHeal:
                    par = enemyTank.HealCur;
                    break;
                case TypeParameter.GetBulletDifferentAngle:
                    par = MathProcessor.CalDifferentAngle(yourTank.Direction, enemyBullet.Direction);
                    break;
            }

            const float epsilon = 1e-6f;
            switch (Operator)
            {
                case TypeOperator.GreaterEqual:
                    if (par >= Value)
                    {
                        return true;
                    }
                    break;
                case TypeOperator.Greater:
                    if (par > Value)
                    {
                        return true;
                    }
                    break;
                case TypeOperator.Equal:
                    if (Math.Abs(par - Value) < epsilon)
                    {
                        return true;
                    }
                    break;
                case TypeOperator.Lower:
                    if (par < Value)
                    {
                        return true;
                    }
                    break;
                case TypeOperator.LowerEqual:
                    if (par <= Value)
                    {
                        return true;
                    }
                    break;
                case TypeOperator.NotEqual:
                    if (Math.Abs(par - Value) > epsilon)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
