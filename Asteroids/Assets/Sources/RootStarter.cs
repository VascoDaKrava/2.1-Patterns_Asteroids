using UnityEngine;


namespace Asteroids
{
    public sealed class RootStarter
    {

        #region Fields

        private InputManager _inputManager;
        private ResourceManager _resourceManager;
        private Rigidbody _shipRigidbody;
        private Transform _bulletStartTransform;
        private Transform _spawnPosition;
        private UpdatableControllersFactory _controllersFactory;

        #endregion


        #region ClassLifeCycles

        public RootStarter(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent)
        {
            _controllersFactory = new UpdatableControllersFactory(createUpdatableObjectEvent, destroyUpdatableObjectEvent);
            _resourceManager = new ResourceManager();
            _inputManager = new InputManager();

            _shipRigidbody = GameObject.FindGameObjectWithTag(TagsAndLayers.PLAYER_TAG).GetComponent<Rigidbody>();
            _bulletStartTransform = GameObject.FindGameObjectWithTag(TagsAndLayers.BULLET_START_POSITION_TAG).transform;
            _spawnPosition = GameObject.FindGameObjectWithTag(TagsAndLayers.SPAWN_POSITION_TAG).transform;

            _controllersFactory.CreateShipController(_inputManager, _shipRigidbody);
            _controllersFactory.CreateFireController(_bulletStartTransform, _inputManager, _resourceManager, _controllersFactory);
            _controllersFactory.CreateEnemySpawner(_spawnPosition, _resourceManager, _controllersFactory);
        }

        #endregion

    }
}
