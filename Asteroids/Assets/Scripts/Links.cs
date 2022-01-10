using UnityEngine;


namespace Asteroids
{

    public sealed class Links
    {

        #region Fields

        private GameStarter _gameStarter;
        private InputManager _inputManager;
        private ResourceManager _resourceManager;
        private Rigidbody _shipRigidbody;
        private ShipController _shipController;
        private Transform _bulletStartPosition;
        private CreateUpdatableObjectEvent _createUpdatableObjectEvent;
        private DestroyUpdatableObjectEvent _destroyUpdatableObjectEvent;

        #endregion


        #region ClassLifeCycles

        public Links(
            GameStarter gameStarter,
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent)
        {
            _gameStarter = gameStarter;
            _createUpdatableObjectEvent = createUpdatableObjectEvent;
            _destroyUpdatableObjectEvent = destroyUpdatableObjectEvent;

            _resourceManager = new ResourceManager();
            _inputManager = new InputManager();

            _shipRigidbody = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).GetComponent<Rigidbody>();

            _bulletStartPosition = GameObject.FindGameObjectWithTag(Tags.BULLET_START_POSITION_TAG).transform;

            _shipController = new ShipController(_inputManager, _shipRigidbody);
            _gameStarter.AddToUpdateList(_shipController);

            new FireController(
                _createUpdatableObjectEvent,
                _destroyUpdatableObjectEvent,
                _bulletStartPosition,
                _inputManager,
                _resourceManager);
        }

        #endregion

    }
}
