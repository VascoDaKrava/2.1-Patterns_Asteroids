using UnityEngine;


namespace Asteroids
{
    public sealed class ShipController : UpdatableObject
    {

        #region Fields

        private Vector3 _moveDirection;
        private InputManager _inputManager;
        private ShipModel _shipModel;
        private ShipView _shipView;

        #endregion


        #region Properties

        /// <summary>
        /// Get value of ship strength
        /// </summary>
        public int ShipStrengthValue
        {
            get => _shipModel.StrengthShip;
        }

        #endregion


        #region ClassLifeCycles

        /// <summary>
        /// Create ShipController
        /// </summary>
        /// <param name="inputManager"></param>
        public ShipController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            InputManager inputManager, 
            Rigidbody rigidbody) :
            base (createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _inputManager = inputManager;

            _shipModel = new ShipModel(rigidbody);
            _shipView = GameObject.FindObjectOfType<ShipView>();

            _shipView.OnGetDamageEvent.OnGetDamage += ChangeStrength;
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

        /// <summary>
        /// Changing ship strength from asteroid damage
        /// </summary>
        /// <param name="value"></param>
        public void ChangeStrength(int value)
        {
            _shipModel.StrengthShip -= value;
            if (_shipModel.StrengthShip <= 0)
            {
                _shipView.DestroyShip();
            }
            _shipView.CurrentStrengthShip(_shipModel.StrengthShip);
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            RemoveFromUpdate();
            _shipView.OnGetDamageEvent.OnGetDamage -= ChangeStrength;
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            LetMoveShip();
        }

        #endregion
    }
}