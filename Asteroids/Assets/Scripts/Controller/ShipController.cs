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

        public ShipController(InputManager inputManager)
        {
            _inputManager = inputManager;
        }

        #endregion

        #region Methods

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

