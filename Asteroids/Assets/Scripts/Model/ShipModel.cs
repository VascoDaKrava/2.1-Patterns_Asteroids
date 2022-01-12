using System;
using UnityEngine;



namespace Asteroids
{
    public sealed class ShipModel : IDisposable
    {
        #region Fields

        private int _strengthShip = 100;

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

        /// <summary>
        /// Current speed of ship
        /// </summary>
        public float SpeedShip { get; set; }

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
        /// Move model by direction
        /// </summary>
        /// <param name="direction"></param>
        public void LetMoveShip(Vector3 direction)
        {
            _shipRigidbody.velocity = direction * _speedShip;
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
        }

        #endregion


    }
}

