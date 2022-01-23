﻿using UnityEngine;

namespace Asteroids
{
    public sealed class EnemySpawner : UpdatableObject
    {

        #region Fields

        private int _enemyInPool = 20;
        private float _rateOfSpawn = 4.0f; // Time in seconds between spawns

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
            UpdatableControllersFactory controllersFactory) :
            base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _spawnPosition = spawnPosition;
            _controllersFactory = controllersFactory;
            _resourceManager = resourceManager;
            _timers = _controllersFactory.CreateTimers();
            _enemyPool = new EnemyPool(_controllersFactory, _resourceManager, _spawnPosition, _enemyInPool);
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
                _enemyPool.Pop(_spawnPosition.position, _spawnPosition.rotation);
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
