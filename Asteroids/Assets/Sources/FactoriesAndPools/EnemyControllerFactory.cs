namespace Asteroids
{
    public sealed class EnemyControllerFactory
    {

        #region Fields

        private CollisionDetectorEvent _collisionDetectorEvent;
        private CreateUpdatableObjectEvent _createUpdatable;
        private DestroyUpdatableObjectEvent _destroyUpdatable;
        private EnemyViewFactory _enemyViewFactory;
        private ResourceManager _resourceManager;
        private TakeDamageEvent _takeDamageEvent;

        #endregion


        #region ClassLifeCycles

        public EnemyControllerFactory(CreateUpdatableObjectEvent createUpdatable,
            DestroyUpdatableObjectEvent destroyUpdatable,
            ResourceManager resourceManager,
            CollisionDetectorEvent collisionDetectorEvent,
            TakeDamageEvent takeDamageEvent)
        {
            _createUpdatable = createUpdatable;
            _collisionDetectorEvent = collisionDetectorEvent;
            _destroyUpdatable = destroyUpdatable;
            _resourceManager = resourceManager;
            _takeDamageEvent = takeDamageEvent;

            _enemyViewFactory = new EnemyViewFactory(_resourceManager);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Create new Small AsteroidController
        /// </summary>
        /// <returns></returns>
        public AsteroidController CreateSmallAsteroidController()
        {
            var controller = new AsteroidController(
                 _createUpdatable,
                 _destroyUpdatable,
                 _collisionDetectorEvent,
                 _takeDamageEvent);

            controller.EnemyModel = new AsteroidSmallModel();
            controller.EnemyView = _enemyViewFactory.CreateSmallAsteroid();
            return controller;
        }

        /// <summary>
        /// Create new Large AsteroidController
        /// </summary>
        /// <returns></returns>
        public AsteroidController CreateLargeAsteroidController()
        {
            var controller = new AsteroidController(
                 _createUpdatable,
                 _destroyUpdatable,
                 _collisionDetectorEvent,
                 _takeDamageEvent);

            controller.EnemyModel = new AsteroidLargeModel();
            controller.EnemyView = _enemyViewFactory.CreateLargeAsteroid();
            return controller;
        }

        /// <summary>
        /// Create new EnemyShipController
        /// </summary>
        /// <returns></returns>
        public EnemyShipController CreateEnemyShipController()
        {
            var controller = new EnemyShipController(
                 _createUpdatable,
                 _destroyUpdatable,
                 _collisionDetectorEvent,
                 _takeDamageEvent);

            controller.EnemyModel = new EnemyShipModel();
            controller.EnemyView = _enemyViewFactory.CreateEnemyShip();
            return controller;
        }

        #endregion

    }
}
