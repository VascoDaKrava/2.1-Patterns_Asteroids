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
        private CreateUpdatableObjectEvent _createUpdatableObjectEvent;
        private DestroyUpdatableObjectEvent _destroyUpdatableObjectEvent;
        

        #endregion


        #region ClassLifeCycles

        public RootStarter(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent)
        {
            _createUpdatableObjectEvent = createUpdatableObjectEvent;
            _destroyUpdatableObjectEvent = destroyUpdatableObjectEvent;

            _resourceManager = new ResourceManager();
            _inputManager = new InputManager();

            _shipRigidbody = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).GetComponent<Rigidbody>();

            _bulletStartPosition = GameObject.FindGameObjectWithTag(Tags.BULLET_START_POSITION_TAG).transform;
            _spawnPosition = GameObject.FindGameObjectWithTag(Tags.SPAWN_POSITION_TAG).transform;

            new ShipController(
                _createUpdatableObjectEvent, 
                _destroyUpdatableObjectEvent, 
                _inputManager, 
                _shipRigidbody);

            new FireController(
                _createUpdatableObjectEvent,
                _destroyUpdatableObjectEvent,
                _bulletStartPosition,
                _inputManager,
                _resourceManager);

            new EnemySpawner(
                _createUpdatableObjectEvent,
                _destroyUpdatableObjectEvent,
                _spawnPosition, 
                _resourceManager);
        }

        #endregion

    }
}
