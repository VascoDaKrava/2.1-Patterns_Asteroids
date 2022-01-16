using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidView: MonoBehaviour, IDamageable
    {

        #region Fields

        private OnTriggerChangeEvent _onTriggerChangeEvent;

        #endregion

        public OnGetDamageEvent OnGetDamageEvent;

        #region Properties

        public OnTriggerChangeEvent OnTriggerChangeEvent
        {
            get => _onTriggerChangeEvent;

            set
            {
                _onTriggerChangeEvent = value;
            }
        }

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            // If enter to the FLYING_AREA do nothing
            if (!other.CompareTag(Tags.FLYING_AREA))
            {

                OnTriggerChangeEvent?.Invoke(this.gameObject, other.gameObject);

                //if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
                //{
                //    damageable.GetDamage(_damage);
                //    DestroyAsteroid();
                //}
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
            OnGetDamageEvent?.Invoke(damage);
        }

        #endregion
    }
}
