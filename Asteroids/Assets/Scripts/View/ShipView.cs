using UnityEngine;


namespace Asteroids
{
    public sealed class ShipView
    {
        #region Fields

        private float _speedShip;
        private int _strengthShip;

        #endregion


        #region Methods

        /// <summary>
        /// Display speed of ship
        /// </summary>
        /// <param name="speed"></param>
        public void CurrentSpeedShip(float speed)
        {
            _speedShip = speed;
            Debug.Log(_speedShip);
        }

        /// <summary>
        /// Display strength of ship
        /// </summary>
        /// <param name="strength"></param>
        public void CurrentStrengthShip(int strength)
        {
            _strengthShip = strength;
            Debug.Log(_strengthShip);
        }

        #endregion
    }
}

