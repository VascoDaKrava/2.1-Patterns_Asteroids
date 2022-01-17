using UnityEngine;


namespace Asteroids
{
    public sealed class RootStarter
    {

        #region Fields

        private InputManager _inputManager;
        private ResourceManager _resourceManager;
        private Rigidbody _shipRigidbody;
        private Transform _bulletStartPosition;
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

            _shipRigidbody = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).GetComponent<Rigidbody>();
            _bulletStartPosition = GameObject.FindGameObjectWithTag(Tags.BULLET_START_POSITION_TAG).transform;
            _spawnPosition = GameObject.FindGameObjectWithTag(Tags.SPAWN_POSITION_TAG).transform;

            _controllersFactory.CreateShipController(_inputManager, _shipRigidbody);
            _controllersFactory.CreateFireController(_bulletStartPosition, _inputManager, _resourceManager, _controllersFactory);
            _controllersFactory.CreateEnemySpawner(_spawnPosition, _resourceManager, _controllersFactory);
        }

        #endregion

    }
}
