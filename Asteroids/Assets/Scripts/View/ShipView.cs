using UnityEngine;


namespace Asteroids
{
    public sealed class ShipView : MonoBehaviour, IDamageable
    {

        #region Fields

        private ShipController _shipController;

        #endregion


        #region Properties

        public ShipController ShipController
        {
            set { _shipController = value; }
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
            _shipController.Dispose();
            Destroy(gameObject);
        }

        #endregion


        #region IDamageable

        public void GetDamage(int damage)
        {
            _shipController.ChangeStrength(damage);
        }

        #endregion
    }
}

