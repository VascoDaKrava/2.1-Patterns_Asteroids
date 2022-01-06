using UnityEngine;


namespace Asteroids
{

    public sealed class Links
    {

        #region Fields

        private GameStarter _gameStarter;
        private ResourceManager _resourceManager;
        private InputManager _inputManager;
        private ShipController _shipController;
        private Rigidbody _shipRigidbody;

        private Transform _bulletStartPosition;

        private FireController _fireController;

        #endregion


        #region ClassLifeCycles

        public Links(GameStarter gameStarter)
        {
            _gameStarter = gameStarter;
            _resourceManager = new ResourceManager();
            _inputManager = new InputManager();

            _shipRigidbody = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).GetComponent<Rigidbody>();

            _bulletStartPosition = GameObject.FindGameObjectWithTag(Tags.BULLET_START_POSITION_TAG).transform;

            _shipController = new ShipController(_inputManager, _shipRigidbody);
            _gameStarter.AddToUpdateList(_shipController);

            _fireController = new FireController(_gameStarter, _bulletStartPosition, _inputManager, _resourceManager);
        }

        #endregion

    }
}
