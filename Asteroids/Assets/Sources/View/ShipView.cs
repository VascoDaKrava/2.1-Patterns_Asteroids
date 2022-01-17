using UnityEngine;


namespace Asteroids
{
    public sealed class ShipView : MonoBehaviour, IDamageable
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

        #endregion


        #region Methods

        /// <summary>
        /// Display strength of ship
        /// </summary>
        /// <param name="strength"></param>
        public void CurrentStrengthShip(int strength)
        {
            Debug.Log(strength);
        }

        /// <summary>
        /// Destroy ship
        /// </summary>
        /// <param name="deathTime"></param>
        public void DestroyShip()
        {
            Destroy(gameObject);
        }

        #endregion


        #region IDamageable

        public void GetDamage(int damage)
        {
           _onGetDamageEvent?.Invoke(damage);
        }

        #endregion

    }
}

