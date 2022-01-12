using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidView: MonoBehaviour, IDamageable
    {

        #region Fields

        private AsteroidController _asteroidController;

        #endregion


        #region Properties

        public AsteroidController AsteroidController
        {
            set { _asteroidController = value; }
        }

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PLAYER_TAG))
            {
                if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    damageable.GetDamage(_asteroidController.AsteroidDamageValue);
                }

                DestroyAsteroid();
            } 
        }

        #endregion


        #region Methods

        /// <summary>
        /// Destroy asteroid
        /// </summary>
        public void DestroyAsteroid()
        {
            _asteroidController.Dispose();
            Destroy(gameObject);
        }

        /// <summary>
        /// Destroy asteroid after a certain time
        /// </summary>
        /// <param name="deathTime"></param>
        public void DestroyAsteroidTime(float deathTime)
        {
            _asteroidController.Dispose();
            Destroy(gameObject, deathTime);
        }

        #endregion


        #region IDamageable

        public void GetDamage (int damage)
        {
            _asteroidController.ChangeStrength(damage);
        }

        #endregion
    }
}
