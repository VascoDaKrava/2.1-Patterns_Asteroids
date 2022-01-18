using UnityEngine;


namespace Asteroids
{
    public sealed class AsteroidView: MonoBehaviour, IDamageable
    {

        #region Fields

        private int _damage;
        private OnGetDamageEvent _onGetDamageEvent;

        #endregion


        #region Properties

        public int Damage
        {
            set { _damage = value; }
        }

        public OnGetDamageEvent OnGetDamageEvent
        {
            get => _onGetDamageEvent;
        }

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _onGetDamageEvent = new OnGetDamageEvent();
        }

        private void OnTriggerEnter(Collider other)
        {
            // If enter to the FLYING_AREA do nothing
            if (!other.CompareTag(Tags.FLYING_AREA))
            {

                if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    damageable.GetDamage(_damage);
                    DestroyAsteroid();
                }
            }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Destroy asteroid
        /// </summary>
        public void DestroyAsteroid()
        {
            Destroy(gameObject);
        }

        /// <summary>
        /// Destroy asteroid after a certain time
        /// </summary>
        /// <param name="deathTime"></param>
        public void DestroyAsteroidTime(float deathTime)
        {
            Destroy(gameObject, deathTime);
        }

        #endregion


        #region IDamageable

        public void GetDamage (int damage)
        {
           _onGetDamageEvent?.Invoke(damage);
        }

        #endregion

    }
}
