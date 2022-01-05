using UnityEngine;


namespace Asteroids
{
    public sealed class ShipController : IUpdatable
    {

        #region Fields

        private Vector3 _moveDirection;
        private InputManager _inputManager;
        private ShipModel _shipModel;

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
        }

        #endregion
    }
}

