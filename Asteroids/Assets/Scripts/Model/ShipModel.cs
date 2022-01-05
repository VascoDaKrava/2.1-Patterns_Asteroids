using UnityEngine;


namespace Asteroids
{
    public sealed class ShipModel : MonoBehaviour
    {
        #region Fields

        private int _strengthShip = 100;
        private int _minStrengthShip = 0;
        private int _maxStrengthShip = 100;

        private float _speedShip = 5.0f;

        private Rigidbody _shipRigidbody;

        #endregion


        #region Properties

        public int StrengthShip
        {
            get => _strengthShip;

            set
            {
                _strengthShip = Mathf.Clamp(_strengthShip + value, _minStrengthShip, _maxStrengthShip);
            }
        }

        public float SpeedShip { get; set; }

        #endregion


        #region UnityMethods

        private void Start()
        {
            _shipRigidbody = GetComponent<Rigidbody>();
        }

        #endregion


        #region Methods

        public void LetMoveShip(Vector3 direction)
        {
            _shipRigidbody.velocity = direction * _speedShip;
        }

        #endregion


    }
}

