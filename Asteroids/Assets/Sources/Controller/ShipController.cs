using UnityEngine;


namespace Asteroids
{
    public sealed class ShipController : UpdatableObject
    {

        #region Fields

        private Vector3 _moveDirection;
        private ShipModel _shipModel;
        private ShipView _shipView;
        private TakeDamageEvent _takeDamageEvent;

        #endregion


        #region ClassLifeCycles

        /// <summary>
        /// Create ShipController
        /// </summary>
        /// <param name="inputManager"></param>
        public ShipController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            Rigidbody rigidbody,
            TakeDamageEvent takeDamageEvent) : base
            (createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _takeDamageEvent = takeDamageEvent;
            _takeDamageEvent.TakeDamage += TakeDamageEventHandler;
            _shipModel = new ShipModel(rigidbody);
            _shipView = GameObject.FindObjectOfType<ShipView>();
        }

        #endregion


        #region Methods

        private void TakeDamageEventHandler(Transform damageReciever, int damage)
        {
            if (damageReciever.TryGetComponent(out ShipView damageRecieverView))
            {
                if (damageRecieverView == _shipView)
                {
                    ChangeStrength(damage);
                }
            }
        }

        /// <summary>
        /// Move ship
        /// </summary>
        private void LetMoveShip()
        {
            _moveDirection = InputManager.GetDirection();

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
                Dispose();
            }
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _takeDamageEvent.TakeDamage -= TakeDamageEventHandler;
            RemoveFromUpdate();
            _shipView.DestroyShip();
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