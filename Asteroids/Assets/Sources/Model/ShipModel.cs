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

        public int StrengthShip
        {
            get => _strengthShip;

            set
            {
                _strengthShip = value;
            }
        }

        public float SpeedShip { get; set; }

        #endregion


        #region ClassLifeCycles

        public ShipModel(Rigidbody rigidbody)
        {
            _shipRigidbody = rigidbody;
        }

        #endregion


        #region Methods

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

