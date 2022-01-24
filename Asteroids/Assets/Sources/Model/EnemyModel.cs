namespace Asteroids
{
    public abstract class EnemyModel
    {

        #region Fields

        private int _armorEnemyShip = 40;

        #endregion

        #region Properties

        public int ArmorEnemyShip
        {
            get => _armorEnemyShip;

            set
            {
                _armorEnemyShip = value;
            }
        }

        /// <summary>
        /// Strength of Asteroid
        /// </summary>
        public abstract int Strength { get; set; }

        /// <summary>
        /// Time for destroy asteroid
        /// </summary>
        public abstract float DeathTime { get; }

        public abstract float Speed { get; }

        public abstract int Damage { get; }

        #endregion
    }
}
