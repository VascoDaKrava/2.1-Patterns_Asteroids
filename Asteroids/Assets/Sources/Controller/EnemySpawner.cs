using System;
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
        private CreateUpdatableObjectEvent _createUpdatableObjectEvent;
        private DestroyUpdatableObjectEvent _destroyUpdatableObjectEvent;

        #endregion


        #region ClassLifeCycles

        public EnemySpawner(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            Transform spawnPosition,
            ResourceManager resourceManager) :
            base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _spawnPosition = spawnPosition;
            _resourceManager = resourceManager;
            _createUpdatableObjectEvent = createUpdatableObjectEvent;
            _destroyUpdatableObjectEvent = destroyUpdatableObjectEvent;
            _timers = new Timers(createUpdatableObjectEvent, destroyUpdatableObjectEvent);
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
                new AsteroidController(
                    _createUpdatableObjectEvent,
                    _destroyUpdatableObjectEvent,
                    _resourceManager,
                    _spawnPosition);
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
