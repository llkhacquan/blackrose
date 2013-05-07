namespace WorldOfTank.Class.Components
{
    /// <summary>
    /// All parameters' Get operators
    /// </summary>
    public enum TypeParameter
    {
        /// <summary>
        /// Self information
        /// </summary>
        GetPositionX,
        GetPositionY,
        GetDirection,
        GetCurrentHeal,

        /// <summary>
        /// Enemy's information
        /// </summary>
        GetEnemyDistance,
        GetEnemyDifferentAngle,
        GetEnemyCurrentHeal,

        /// <summary>
        /// Enemy bullet's information
        /// </summary>
        GetBulletDifferentAngle,
    }
}
