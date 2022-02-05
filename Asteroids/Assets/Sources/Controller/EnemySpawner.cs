using UnityEngine;

namespace Asteroids
{
    public sealed class EnemySpawner : UpdatableObject
    {

        #region Fields

        private int _enemyInPool = 20;
        private float _rateOfSpawn = 4.0f; // Time in seconds between spawns
        private float _minSpawnPositionX = -50.0f;
        private float _maxSpawnPositionX = 50.0f;
        private Vector3 _spawnPosition = new Vector3(0.0f, 0.0f, 110.0f);

        private Timers _timers;
        private UpdatableControllersFactory _controllersFactory;
        private EnemyPool _enemyPool;

        #endregion


        #region ClassLifeCycles

        public EnemySpawner(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            UpdatableControllersFactory controllersFactory) : base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _controllersFactory = controllersFactory;
            _timers = _controllersFactory.CreateTimers();
            _enemyPool = new EnemyPool(_controllersFactory, _enemyInPool);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Spawn asteroids after a certain time
        /// </summary>
        private void EnemySpawn()
        {
            if (!_timers.isTimerOn)
            {
                _timers.StartTimer(_rateOfSpawn);
                _spawnPosition.x = Random.Range(_minSpawnPositionX, _maxSpawnPositionX);

                _enemyPool.Pop(
                    _spawnPosition,
                    Quaternion.identity);
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
