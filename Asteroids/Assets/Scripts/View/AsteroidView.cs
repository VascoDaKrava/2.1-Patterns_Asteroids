using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidView: MonoBehaviour
    {

        #region Fields

        private int _strength;
        private int _damage;
        private float _timeOfDeath = 5.0f;

        #endregion


        #region Properties

        public int Strength
        {
            set { _strength = value; }
        }

        public int Damage
        {
            set { _damage = value; }
        }

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.GetDamage(_damage);
            }

            DestroyAsteroid();
        }

        #endregion


        #region Methods

        private void DestroyAsteroid()
        {
            Destroy(gameObject, _timeOfDeath);
        }

        #endregion

    }
}
