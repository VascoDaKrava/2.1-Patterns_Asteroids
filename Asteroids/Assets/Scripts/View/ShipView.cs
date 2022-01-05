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

        public void CurrentSpeedShip(float speed)
        {
            _speedShip = speed;
            Debug.Log(_speedShip);
        }

        public void CurrentStrengthShip(int strength)
        {
            _strengthShip = strength;
            Debug.Log(_strengthShip);
        }

        #endregion
    }
}

