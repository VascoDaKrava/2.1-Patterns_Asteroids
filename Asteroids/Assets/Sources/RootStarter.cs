using UnityEngine;


namespace Asteroids
{
    public sealed class RootStarter
    {

        #region Fields

        private InputManager _inputManager;
        private ResourceManager _resourceManager;
        private ResourceManagerAudioClips _resourceManagerAudioClips;
        private Rigidbody _shipRigidbody;
        private Transform _bulletStartTransform;
        private Transform _spawnPosition;
        private UpdatableControllersFactory _controllersFactory;
        private CollisionDetectorEvent _collisionDetectorEvent;
        private TakeDamageEvent _takeDamageEvent;

        #endregion


        #region ClassLifeCycles

        public RootStarter(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent)
        {
            _resourceManager = new ResourceManager();
            _resourceManagerAudioClips = new ResourceManagerAudioClips();
            _inputManager = new InputManager();
            _collisionDetectorEvent = new CollisionDetectorEvent();
            _takeDamageEvent = new TakeDamageEvent();

            _controllersFactory = new UpdatableControllersFactory(
                createUpdatableObjectEvent,
                destroyUpdatableObjectEvent,
                _resourceManager,
                _collisionDetectorEvent,
                _takeDamageEvent);

            _shipRigidbody = GameObject.FindGameObjectWithTag(TagsAndLayers.PLAYER_TAG).GetComponent<Rigidbody>();
            _bulletStartTransform = GameObject.FindGameObjectWithTag(TagsAndLayers.BULLET_START_POSITION_TAG).transform;
            _spawnPosition = GameObject.FindGameObjectWithTag(TagsAndLayers.SPAWN_POSITION_TAG).transform;

            _controllersFactory.CreateShipController(_inputManager, _shipRigidbody);
            _controllersFactory.CreateFireController(_bulletStartTransform, _inputManager, _controllersFactory);
            _controllersFactory.CreateEnemySpawner(_spawnPosition, _resourceManager, _controllersFactory);

            new SoundSystemPlayController(_resourceManagerAudioClips);
        }

        #endregion

    }
}
