using UnityEngine;


namespace Asteroids
{

    public sealed class FireController : UpdatableObject
    {

        #region Fields

        private float _rateOfFire = 1.0f; // Time in seconds between shots
        private int _misselesInPool = 3;

        private Transform _bulletStartTransform;
        private Timers _timers;
        private InputManager _inputManager;
        private UpdatableControllersFactory _controllersFactory;
        private MissilePool _missilePool;
        private bool _isAutoFireOn;

        #endregion


        #region ClassLifeCycles

        public FireController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            Transform bulletStartTransform,
            InputManager inputManagerLink,
            ResourceManager resourceManager,
            UpdatableControllersFactory controllersFactory) :
            base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _bulletStartTransform = bulletStartTransform;
            _inputManager = inputManagerLink;
            _controllersFactory = controllersFactory;
            _timers = _controllersFactory.CreateTimers();
            _missilePool = new MissilePool(controllersFactory, resourceManager, _misselesInPool);
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
                    _missilePool.Pop(_bulletStartTransform.position, _bulletStartTransform.rotation);
                }
            }
        }

        private void ChangeAutoFire()
        {
            if (_inputManager.isSecondFire)
                _isAutoFireOn = !_isAutoFireOn;

            if (_isAutoFireOn)
                DoAutoFire();
        }

        private void DoAutoFire()
        {
            foreach (Collider item in Physics.OverlapSphere(_bulletStartTransform.position, 100f))
            {
                Debug.Log($"C : {item.gameObject}, D = {Vector3.Distance(item.transform.position, _bulletStartTransform.position)}");
            }
            _isAutoFireOn = false;
        }

        #endregion


        #region UpdatableObject / IUpdatable

        public override void LetUpdate()
        {
            TryFire();
            ChangeAutoFire();
        }

        #endregion

    }
}
