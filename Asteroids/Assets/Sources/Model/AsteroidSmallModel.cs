namespace Asteroids
{
    public sealed class AsteroidSmallModel : EnemyModel
    {

        #region Fields

        private int _strengthAsteroid = 20;
        private float _speedAsteroid = 10.0f;
        private int _damageAsteroid = 20;
        private float _deathTime = 30.0f;

        #endregion


        #region Properties

        public override int Strength
        {
            get => _strengthAsteroid;

            set
            {
                _strengthAsteroid = value;
            }
        }

        public override float DeathTime { get => _deathTime; }

        public override float Speed { get => _speedAsteroid; }

        public override int Damage { get => _damageAsteroid; }

        #endregion

    }
}
