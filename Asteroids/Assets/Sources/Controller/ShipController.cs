using UnityEngine;
using UnityEngine.SceneManagement;


namespace Asteroids
{
    public sealed class ShipController : UpdatableObject
    {

        #region Fields

        private Vector3 _moveDirection;
        private InputManager _inputManager;
        private ResourceManager _resourceManager;
        private ShipModel _shipModel;
        private ShipView _shipView;
        private TakeDamageEvent _takeDamageEvent;
        private DisplayEndGame _displayEndGame;


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
            ResourceManager resourceManager,
            Rigidbody rigidbody,
            TakeDamageEvent takeDamageEvent) : base
            (createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _inputManager = inputManager;
            _resourceManager = resourceManager;
            _takeDamageEvent = takeDamageEvent;
            _takeDamageEvent.TakeDamage += TakeDamageEventHandler;
            _shipModel = new ShipModel(rigidbody);
            _shipView = GameObject.FindObjectOfType<ShipView>();
            _displayEndGame = new DisplayEndGame();
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
            _displayEndGame.GameOver(_resourceManager);
            Time.timeScale = 6.0f;
            SceneManager.LoadScene(1);
            
            Dispose();
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