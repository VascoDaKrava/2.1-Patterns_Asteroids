using UnityEngine;


namespace Asteroids
{

    public sealed class FireController : UpdatableObject
    {

        #region Fields

        private float _rateOfFire = 2.0f; // Time in seconds between shots

        private Transform _bulletStartPosition;
        private Timers _timers;
        private InputManager _inputManager;
        private ResourceManager _resourceManager;
        private GameStarter _gameStarter;

        #endregion


        #region ClassLifeCycles

        public FireController(
            GameStarter gameStarter,
            Transform bulletStartPosition,
            InputManager inputManagerLink,
            ResourceManager resourceManager) : base(gameStarter)
        {
            _bulletStartPosition = bulletStartPosition;
            _inputManager = inputManagerLink;
            _resourceManager = resourceManager;
            _gameStarter = gameStarter;
            _timers = new Timers(gameStarter);
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
                    new MissileController(_gameStarter, _resourceManager, _bulletStartPosition);
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
