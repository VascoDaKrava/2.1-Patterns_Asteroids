using UnityEngine;


namespace Asteroids
{
    public sealed class AsteroidLargeModel : EnemyModel
    {

        #region Fields

        private int _strengthAsteroid = 60;
        private float _speedAsteroid = 7.0f;
        private int _damageAsteroid = 30;
        private float _deathTime = 20.0f;

        #endregion

        #region Properties

        /// <summary>
        /// Strength of Asteroid
        /// </summary>
        public override int Strength
        {
            get => _strengthAsteroid;

            set
            {
                _strengthAsteroid = value;
            }
        }

        /// <summary>
        /// Time for destroy asteroid
        /// </summary>
        public override float DeathTime { get => _deathTime; }

        public override float Speed { get => _speedAsteroid; }

        public override int Damage { get => _damageAsteroid; }

        #endregion

    }
}
