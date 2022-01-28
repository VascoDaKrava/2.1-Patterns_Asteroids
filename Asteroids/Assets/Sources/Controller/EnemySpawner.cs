using UnityEngine;

namespace Asteroids
{
    public sealed class EnemySpawner : UpdatableObject
    {

        #region Fields

        private int _enemyInPool = 20;
        private float _rateOfSpawn = 4.0f;
        private float _minSpawnPositionX = -50.0f;
        private float _maxSpawnPositionX = 50.0f;

        private Transform _spawnPosition;
        private Timers _timers;
        private UpdatableControllersFactory _controllersFactory;
        private ResourceManager _resourceManager;
        private EnemyPool _enemyPool;

        #endregion


        #region ClassLifeCycles

        public EnemySpawner(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            ResourceManager resourceManager,
            Transform spawnPosition,
            UpdatableControllersFactory controllersFactory) : base
            (createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _spawnPosition = spawnPosition;
            _controllersFactory = controllersFactory;
            _resourceManager = resourceManager;
            _timers = _controllersFactory.CreateTimers();
            _enemyPool = new EnemyPool(_controllersFactory, _resourceManager, _spawnPosition, _enemyInPool);
        }

        #endregion


        #region Methods

        private void EnemySpawn()
        {
            if (!_timers.isTimerOn)
            {
                _timers.StartTimer(_rateOfSpawn);
                _enemyPool.Pop(_spawnPosition.position = new Vector3(
                    Random.Range(_minSpawnPositionX, _maxSpawnPositionX),
                _spawnPosition.position.y, _spawnPosition.position.z),
                _spawnPosition.rotation);
            }
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            EnemySpawn();
        }

        #endregion

    }
}
