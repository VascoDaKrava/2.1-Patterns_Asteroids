using UnityEngine;


namespace Asteroids
{
    /// <summary>
    /// Class for injecting dependencies when Controllers were creating and using as UpdatableObject
    /// </summary>
    public sealed class UpdatableControllersFactory
    {

        #region Fields

        private CreateUpdatableObjectEvent _createUpdatable;
        private DestroyUpdatableObjectEvent _destroyUpdatable;
        private ResourceManager _resourceManager;
        private CollisionDetectorEvent _collisionDetectorEvent;
        private TakeDamageEvent _takeDamageEvent;
        private EnemyFactory _enemyFactory;
        private SoundSystemPlayController _soundSystemPlayController;
        private ResourceManagerAudioClips _resourceManagerAudioClips;

        #endregion


        #region ClassLifeCicles

        public UpdatableControllersFactory(
            CreateUpdatableObjectEvent createUpdatable,
            DestroyUpdatableObjectEvent destroyUpdatable,
            ResourceManager resourceManager,
            CollisionDetectorEvent collisionDetectorEvent,
            TakeDamageEvent takeDamageEvent,
            SoundSystemPlayController soundSystemPlayController,
            ResourceManagerAudioClips resourceManagerAudioClips)
        {
            _createUpdatable = createUpdatable;
            _destroyUpdatable = destroyUpdatable;
            _resourceManager = resourceManager;
            _collisionDetectorEvent = collisionDetectorEvent;
            _takeDamageEvent = takeDamageEvent;
            _enemyFactory = new EnemyFactory();
            _soundSystemPlayController = soundSystemPlayController;
            _resourceManagerAudioClips = resourceManagerAudioClips;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Create new ShipController
        /// </summary>
        /// <param name="inputManager">Link to InputManager</param>
        /// <param name="rigidbody">Link to ship Rigidbody</param>
        /// <returns></returns>
        public ShipController CreateShipController(
            InputManager inputManager,
            Rigidbody rigidbody)
        {
            return new ShipController(
                _createUpdatable,
                _destroyUpdatable,
                inputManager,
                rigidbody,
                _takeDamageEvent,
                 _soundSystemPlayController,
                _resourceManagerAudioClips);
        }

        /// <summary>
        /// Create new FireController
        /// </summary>
        /// <param name="bulletStartPosition">Link to Transform, where bullet was instantiate</param>
        /// <param name="inputManagerLink">Link to InputManager</param>
        /// <param name="updatableControllersFactory">Link to ControllersFactory</param>
        /// <returns></returns>
        public FireController CreateFireController(
            Transform bulletStartPosition,
            InputManager inputManagerLink,
            UpdatableControllersFactory updatableControllersFactory)
        {
            return new FireController(
                _createUpdatable,
                _destroyUpdatable,
                bulletStartPosition,
                inputManagerLink,
                updatableControllersFactory,
                _soundSystemPlayController,
                _resourceManagerAudioClips);
        }

        /// <summary>
        /// Create new LineMissileController
        /// </summary>
        /// <param name="bulletStartPosition">Position, where bullet was instantiate</param>
        /// <param name="bulletStartDirection">Direction of bullet, when it was instantiate</param>
        /// <returns></returns>
        public LineMissileController CreateMissileController(
            Vector3 bulletStartPosition,
            Quaternion bulletStartDirection)
        {
            return new LineMissileController(
                _createUpdatable,
                _destroyUpdatable,
                _resourceManager,
                bulletStartPosition,
                bulletStartDirection,
                _collisionDetectorEvent,
                _takeDamageEvent);
        }

        /// <summary>
        /// Create new HomingMissileController
        /// </summary>
        /// <param name="bulletStartPosition">Position, where bullet was instantiate</param>
        /// <param name="bulletStartDirection">Direction of bullet, when it was instantiate</param>
        /// <param name="target">Transform of target of missile</param>
        /// <returns></returns>
        public HomingMissileController CreateMissileController(
            Vector3 bulletStartPosition,
            Quaternion bulletStartDirection,
            Transform target)
        {
            return new HomingMissileController(
                _createUpdatable,
                _destroyUpdatable,
                _resourceManager,
                bulletStartPosition,
                bulletStartDirection,
                _collisionDetectorEvent,
                _takeDamageEvent,
                target);
        }

        /// <summary>
        /// Create new Timers
        /// </summary>
        /// <returns></returns>
        public Timers CreateTimers()
        {
            return new Timers(
                _createUpdatable,
                _destroyUpdatable);
        }

        /// <summary>
        /// Create new EnemySpawner
        /// </summary>
        /// <param name="spawnPosition">Link to Transform, where Enemy was instantiate</param>
        /// <param name="controllersFactory">Link to ControllersFactory</param>
        /// <returns></returns>
        public EnemySpawner CreateEnemySpawner(
            Transform spawnPosition,
            ResourceManager resourceManager,
            UpdatableControllersFactory controllersFactory)
        {
            return new EnemySpawner(
                _createUpdatable,
                _destroyUpdatable,
                resourceManager,
                spawnPosition,
                controllersFactory,
                _soundSystemPlayController,
                _resourceManagerAudioClips);
        }

        /// <summary>
        /// Create new Small AsteroidController
        /// </summary>
        /// <param name="spawnPosition">Link to Transform, where Enemy was instantiate</param>
        /// <returns></returns>
        public AsteroidController CreateSmallAsteroidController(ResourceManager resourceManager,
            Transform spawnPosition)
        {
           var controller = new AsteroidController(
                _createUpdatable,
                _destroyUpdatable,
                _collisionDetectorEvent,
                _takeDamageEvent);

            controller.EnemyModel = new AsteroidSmallModel();
            controller.EnemyView = _enemyFactory.CreateSmallAsteroid(resourceManager, spawnPosition);
            return controller;
        }

        /// <summary>
        /// Create new Large AsteroidController
        /// </summary>
        /// <param name="spawnPosition">Link to Transform, where Enemy was instantiate</param>
        /// <returns></returns>
        public AsteroidController CreateLargeAsteroidController(ResourceManager resourceManager,
            Transform spawnPosition)
        {
            var controller = new AsteroidController(
                 _createUpdatable,
                 _destroyUpdatable,
                 _collisionDetectorEvent,
                 _takeDamageEvent);

            controller.EnemyModel = new AsteroidLargeModel();
            controller.EnemyView = _enemyFactory.CreateLargeAsteroid(resourceManager, spawnPosition);
            return controller;
        }

        /// <summary>
        /// Create new EnemyShipController
        /// </summary>
        /// <param name="spawnPosition">Link to Transform, where Enemy was instantiate</param>
        /// <returns></returns>
        public EnemyShipController CreateEnemyShipController(ResourceManager resourceManager, Transform spawnPosition)
        {
            var controller = new EnemyShipController(
                 _createUpdatable,
                 _destroyUpdatable,
                 _collisionDetectorEvent,
                 _takeDamageEvent);

            controller.EnemyModel = new EnemyShipModel();
            controller.EnemyView = _enemyFactory.CreateEnemyShip(resourceManager, spawnPosition);
            return controller;
        }

        #endregion

    }
}
