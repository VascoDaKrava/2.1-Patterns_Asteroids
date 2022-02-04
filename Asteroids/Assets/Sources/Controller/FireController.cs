using UnityEngine;


namespace Asteroids
{

    public sealed class FireController : UpdatableObject
    {

        #region Fields

        private int _misselesInPool = 3;
        private float _rateOfFire = 1.0f; // Time in seconds between shots
        private float _sonarRange = 50.0f;
        private float _sonarReloadTime = 5.0f; // Time in seconds between using sonar/autofire

        private Transform _bulletStartTransform;
        private Transform _enemyTargetTransform;
        private Timers _primaryFireTimer;
        private Timers _sonarTimer;
        private UpdatableControllersFactory _controllersFactory;
        private MissilePool _missilePool;
        private bool _isAutoFireOn;

        #endregion


        #region ClassLifeCycles

        public FireController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            Transform bulletStartTransform,
            UpdatableControllersFactory controllersFactory) : base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _bulletStartTransform = bulletStartTransform;
            _controllersFactory = controllersFactory;
            _primaryFireTimer = _controllersFactory.CreateTimers();
            _sonarTimer = _controllersFactory.CreateTimers();
            _missilePool = new MissilePool(controllersFactory, _misselesInPool);
        }

        #endregion


        #region Methods

        private void PrimaryFire()
        {
            if (InputManager.isPrimaryFire)
            {
                if (!_primaryFireTimer.isTimerOn)
                {
                    _primaryFireTimer.StartTimer(_rateOfFire);
                    _missilePool.Pop(_bulletStartTransform.position, _bulletStartTransform.rotation);
                }
            }
        }

        private void SecondaryFire()
        {
            if (InputManager.isSecondaryFire)
            {
                _isAutoFireOn = !_isAutoFireOn;
            }

            if (_isAutoFireOn)
            {
                if (!_sonarTimer.isTimerOn)
                {
                    _sonarTimer.StartTimer(_sonarReloadTime);
                    if (StartSonar(_bulletStartTransform.position, _sonarRange, out _enemyTargetTransform))
                    {
                        StartHomingMissile(_enemyTargetTransform);
                    }
                }
            }
        }

        private void StartHomingMissile(Transform target)
        {
            _controllersFactory.CreateMissileController(_bulletStartTransform.position, _bulletStartTransform.rotation, target);
        }

        /// <summary>
        /// Search enemies in radius of startPosition and return nearest as target
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="radius"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool StartSonar(Vector3 startPosition, float radius, out Transform target)
        {
            target = null;
            float nearestDistance = float.PositiveInfinity;
            float currentDistanceToTarget;

            foreach (Collider item in Physics.OverlapSphere(startPosition, radius, TagsAndLayers.ENEMY_LAYER, QueryTriggerInteraction.Collide))
            {
                currentDistanceToTarget = Vector3.Distance(item.transform.position, _bulletStartTransform.position);

                if (nearestDistance > currentDistanceToTarget)
                {
                    nearestDistance = currentDistanceToTarget;
                    target = item.transform;
                }
            }

            return target;
        }

        #endregion


        #region UpdatableObject / IUpdatable

        public override void LetUpdate()
        {
            PrimaryFire();
            SecondaryFire();
        }

        #endregion

    }
}
