namespace Asteroids
{
    public sealed class EnemyShipModel : EnemyModel
    {

        #region Fields

        private int _strengthEnemyShip = 50;
        private int _armorEnemyShip = 40;
        private float _speedEnemyShip = 5.0f;
        private int _damageEnemyShip = 50;
        private float _deathTime = 30.0f;

        #endregion


        #region Properties

        public int Armor
        {
            get => _armorEnemyShip;

            set
            {
                _armorEnemyShip = value;
            }
        }

        /// <summary>
        /// Strength of EnemyShip
        /// </summary>
        public override int Strength
        {
            get => _strengthEnemyShip;

            set
            {
                _strengthEnemyShip = value;
            }
        }

        /// <summary>
        /// Time for destroy EnemyShip
        /// </summary>
        public override float DeathTime { get => _deathTime; }

        public override float Speed { get => _speedEnemyShip; }

        public override int Damage { get => _damageEnemyShip; }

        #endregion
    }
}
