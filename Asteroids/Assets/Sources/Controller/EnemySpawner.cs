using UnityEngine;

namespace Asteroids
{
    public sealed class EnemySpawner : UpdatableObject
    {

        #region Fields

        private float _rateOfSpawn = 4.0f; // Time in seconds between spawns

        private Transform _spawnPosition;
        private Timers _timers;
        private ResourceManager _resourceManager;
        private UpdatableControllersFactory _controllersFactory;

        #endregion


        #region ClassLifeCycles

        public EnemySpawner(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            Transform spawnPosition,
            ResourceManager resourceManager,
            UpdatableControllersFactory controllersFactory) :
            base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _spawnPosition = spawnPosition;
            _resourceManager = resourceManager;
            _controllersFactory = controllersFactory;
            _timers = _controllersFactory.CreateTimers();
        }

        #endregion


        #region Methods

        /// <summary>
        /// Spawn asteroids after a certain time
        /// </summary>
        private void AsteroidSpawn()
        {

            if (!_timers.isTimerOn)
            {
                _timers.StartTimer(_rateOfSpawn);
                _controllersFactory.CreateAsteroidController(_resourceManager, _spawnPosition);
            }
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            AsteroidSpawn();
        }

        #endregion

    }
}
