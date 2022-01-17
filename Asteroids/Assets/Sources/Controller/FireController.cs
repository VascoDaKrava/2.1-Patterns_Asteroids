using UnityEngine;


namespace Asteroids
{

    public sealed class FireController : UpdatableObject
    {

        #region Fields

        private float _rateOfFire = 1.0f; // Time in seconds between shots

        private Transform _bulletStartPosition;
        private Timers _timers;
        private InputManager _inputManager;
        private ResourceManager _resourceManager;
        private UpdatableControllersFactory _controllersFactory;

        #endregion


        #region ClassLifeCycles

        public FireController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            Transform bulletStartPosition,
            InputManager inputManagerLink,
            ResourceManager resourceManager,
            UpdatableControllersFactory controllersFactory) :
            base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _bulletStartPosition = bulletStartPosition;
            _inputManager = inputManagerLink;
            _resourceManager = resourceManager;
            _controllersFactory = controllersFactory;
            _timers = _controllersFactory.CreateTimers();
        }

        #endregion


        #region Methods

        private void TryFire()
        {
            if (_inputManager.isFire)
            {
                if (!_timers.isTimerOn)
                {
                    _timers.StartTimer(_rateOfFire);
                    _controllersFactory.CreateMissileController(_resourceManager, _bulletStartPosition);
                }
            }
        }

        #endregion


        #region UpdatableObject / IUpdatable

        public override void LetUpdate()
        {
            TryFire();
        }

        #endregion

    }
}
