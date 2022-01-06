using UnityEngine;


namespace Asteroids
{
    public sealed class ShipModel
    {
        #region Fields

        private int _strengthShip = 100;
        private int _minStrengthShip = 0;
        private int _maxStrengthShip = 100;

        private float _speedShip = 5.0f;

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
                _strengthShip = Mathf.Clamp(_strengthShip + value, _minStrengthShip, _maxStrengthShip);
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


    }
}

