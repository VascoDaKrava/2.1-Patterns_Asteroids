using UnityEngine;


namespace Asteroids
{
    public sealed class UpdatableControllersFactory
    {

        #region Fields

        private CreateUpdatableObjectEvent _createUpdatable;
        private DestroyUpdatableObjectEvent _destroyUpdatable;
        private ResourceManager _resourceManager;
        private CollisionDetectorEvent _collisionDetectorEvent;
        private TakeDamageEvent _takeDamageEvent;
        private EnemyFactory _enemyFactory;

        #endregion


        #region ClassLifeCicles

        public UpdatableControllersFactory(
            CreateUpdatableObjectEvent createUpdatable,
            DestroyUpdatableObjectEvent destroyUpdatable,
            ResourceManager resourceManager,
            CollisionDetectorEvent collisionDetectorEvent,
            TakeDamageEvent takeDamageEvent)
        {
            _createUpdatable = createUpdatable;
            _destroyUpdatable = destroyUpdatable;
            _resourceManager = resourceManager;
            _collisionDetectorEvent = collisionDetectorEvent;
            _takeDamageEvent = takeDamageEvent;
            _enemyFactory = new EnemyFactory();
        }

        #endregion


        #region Methods

        public ShipController CreateShipController(
            InputManager inputManager,
            Rigidbody rigidbody)
        {
            return new ShipController(
                _createUpdatable,
                _destroyUpdatable,
                inputManager,
                rigidbody,
                _takeDamageEvent);
        }

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
                updatableControllersFactory);
        }

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

        public Timers CreateTimers()
        {
            return new Timers(
                _createUpdatable,
                _destroyUpdatable);
        }

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
                controllersFactory);
        }

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
