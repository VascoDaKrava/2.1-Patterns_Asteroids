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
        private CreateUpdatableObjectEvent _createUpdatableObjectEvent;
        private DestroyUpdatableObjectEvent _destroyUpdatableObjectEvent;

        #endregion


        #region ClassLifeCycles

        public FireController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            Transform bulletStartPosition,
            InputManager inputManagerLink,
            ResourceManager resourceManager) :
            base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _bulletStartPosition = bulletStartPosition;
            _inputManager = inputManagerLink;
            _resourceManager = resourceManager;
            _createUpdatableObjectEvent = createUpdatableObjectEvent;
            _destroyUpdatableObjectEvent = destroyUpdatableObjectEvent;
            _timers = new Timers(createUpdatableObjectEvent, destroyUpdatableObjectEvent);
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
                    new MissileController(
                        _createUpdatableObjectEvent,
                        _destroyUpdatableObjectEvent,
                        _resourceManager,
                        _bulletStartPosition);
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
