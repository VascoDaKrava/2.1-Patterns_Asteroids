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

        private FireController _fireController;

        #endregion


        #region Properties

        public DestroyUpdatableObjectEvent DestroyUpdatableObjectEvent { get; }
        public CreateUpdatableObjectEvent CreateUpdatableObjectEvent { get; }

        #endregion


        #region ClassLifeCycles

        public Links(GameStarter gameStarter)
        {
            _gameStarter = gameStarter;
            _resourceManager = new ResourceManager();
            _inputManager = new InputManager();
            DestroyUpdatableObjectEvent = new DestroyUpdatableObjectEvent();
            CreateUpdatableObjectEvent = new CreateUpdatableObjectEvent();

            _shipRigidbody = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).GetComponent<Rigidbody>();

            _bulletStartPosition = GameObject.FindGameObjectWithTag(Tags.BULLET_START_POSITION_TAG).transform;

            _shipController = new ShipController(_inputManager, _shipRigidbody);
            _gameStarter.AddToUpdateList(_shipController);

            _fireController = new FireController(_gameStarter, _bulletStartPosition, _inputManager, _resourceManager);
        }

        #endregion

    }
}
