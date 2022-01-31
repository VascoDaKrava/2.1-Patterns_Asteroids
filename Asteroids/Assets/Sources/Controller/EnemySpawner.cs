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

        private Transform _spawnPosition;
        private Timers _timers;
        private UpdatableControllersFactory _controllersFactory;
        private ResourceManager _resourceManager;
        private EnemyPool _enemyPool;
        private SoundSystemPlayController _soundSystemPlayController;
        private ResourceManagerAudioClips _resourceManagerAudioClips;

        #endregion


        #region ClassLifeCycles

        public EnemySpawner(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            ResourceManager resourceManager,
            Transform spawnPosition,
            UpdatableControllersFactory controllersFactory,
            SoundSystemPlayController soundSystemPlayController,
            ResourceManagerAudioClips resourceManagerAudioClips) : base
            (createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _spawnPosition = spawnPosition;
            _controllersFactory = controllersFactory;
            _resourceManager = resourceManager;
            _timers = _controllersFactory.CreateTimers();
            _enemyPool = new EnemyPool(_controllersFactory, _resourceManager, _spawnPosition, _enemyInPool);
            _soundSystemPlayController = soundSystemPlayController;
            _resourceManagerAudioClips = resourceManagerAudioClips;
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
                _enemyPool.Pop(_spawnPosition.position = new Vector3(
                    Random.Range(_minSpawnPositionX, _maxSpawnPositionX),
                _spawnPosition.position.y, _spawnPosition.position.z),
                _spawnPosition.rotation);
                _soundSystemPlayController.PlaybackSFX(_resourceManagerAudioClips.AudioClipSpawnEnemy);
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
