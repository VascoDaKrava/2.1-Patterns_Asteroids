using UnityEngine;


namespace Asteroids
{
    public sealed class ShipController : IUpdatable
    {

        #region Fields

        private Vector3 _moveDirection;
        private InputManager _inputManager;
        private ShipModel _shipModel;
        private ShipView _shipView;

        #endregion


        #region ClassLifeCycles

        /// <summary>
        /// Create ShipController
        /// </summary>
        /// <param name="inputManager"></param>
        public ShipController(InputManager inputManager, Rigidbody rigidbody)
        {
            _inputManager = inputManager;

            _shipModel = new ShipModel(rigidbody);
            _shipView = new ShipView();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Move ship
        /// </summary>
        private void LetMoveShip()
        {
            _moveDirection = _inputManager.GetDirection();

            if (_moveDirection != Vector3.zero)
            {
                _shipModel.LetMoveShip(_moveDirection);
            }
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            LetMoveShip();

            _shipView.CurrentSpeedShip(_shipModel.SpeedShip);
            _shipView.CurrentStrengthShip(_shipModel.StrengthShip);
        }

        #endregion
    }
}