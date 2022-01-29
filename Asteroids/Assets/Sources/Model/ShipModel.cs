using UnityEngine;


namespace Asteroids
{
    public sealed class ShipModel
    {

        #region Fields

        private int _strengthShip = 200;

        private float _speedShip = 10.0f;

        private Rigidbody _shipRigidbody;

        #endregion


        #region Properties

        /// <summary>
        /// Current strength of ship
        /// </summary>
        public int StrengthShip
        {
            get => _strengthShip;

            set
            {
                _strengthShip = value;
            }
        }

        #endregion


        #region ClassLifeCycles

        /// <summary>
        /// Get link a rigidbody of ship
        /// </summary>
        /// <param name="rigidbody"></param>
        public ShipModel(Rigidbody rigidbody)
        {
            _shipRigidbody = rigidbody;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Move ship by direction
        /// </summary>
        /// <param name="direction"></param>
        public void LetMoveShip(Vector3 direction)
        {
            if (_shipRigidbody != null)
            {
                _shipRigidbody.velocity = direction * _speedShip;
            }
        }

        #endregion

    }
}

