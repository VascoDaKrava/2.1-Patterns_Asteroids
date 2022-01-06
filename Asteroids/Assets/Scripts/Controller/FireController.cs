using UnityEngine;


namespace Asteroids
{

    public sealed class FireController : UpdatableObject
    {

        #region Fields

        private float _rateOfFire = 2.0f; // Time in seconds between shots

        private Transform _bulletStartPosition;
        private Timers _timers;
        private InputManager _inputManagerLink;
        private GameObject _bullet;

        #endregion


        #region ClassLifeCycles

        public FireController(
            GameStarter gameStarter,
            Transform bulletStartPositionLink,
            InputManager inputManagerLink,
            ResourceManager resourceManagerLink) : base(gameStarter)
        {
            _bulletStartPosition = bulletStartPositionLink;
            _inputManagerLink = inputManagerLink;
            _bullet = resourceManagerLink.MissileAIM9 as GameObject;
            _timers = new Timers(gameStarter);
        }

        #endregion


        #region Methods

        private void TryFire()
        {
            if (_inputManagerLink.isFire)
            {
                if (!_timers.isTimerOn)
                {
                    _timers.StartTimer(_rateOfFire);
                    GameObject.Instantiate(
                        _bullet,
                        _bulletStartPosition.position,
                        _bulletStartPosition.rotation,
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
