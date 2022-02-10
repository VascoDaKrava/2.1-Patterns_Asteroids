namespace Asteroids
{
    public sealed class EnemyShipModel : EnemyModel
    {

        #region Fields

        private int _strengthEnemyShip = 50;
        private float _speedEnemyShip = 8.0f;
        private int _damageEnemyShip = 50;
        private float _deathTime = 45.0f;

        #endregion


        #region Properties

        public override int Strength
        {
            get => _strengthEnemyShip;

            set
            {
                _strengthEnemyShip = value;
            }
        }

        public override float DeathTime { get => _deathTime; }

        public override float Speed { get => _speedEnemyShip; }

        public override int Damage { get => _damageEnemyShip; }

        #endregion

    }
}
