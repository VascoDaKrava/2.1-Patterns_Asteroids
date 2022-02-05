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
        private EnemyControllerFactory _enemyControllersFactory;
        private MissileControllerFactory _missileControllersFactory;
        private TakeDamageEvent _takeDamageEvent;

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
            _takeDamageEvent = takeDamageEvent;

            _enemyControllersFactory = new EnemyControllerFactory(
                createUpdatable,
                destroyUpdatable,
                resourceManager,
                collisionDetectorEvent,
                takeDamageEvent);

            _missileControllersFactory = new MissileControllerFactory(
                collisionDetectorEvent,
                createUpdatable,
                destroyUpdatable,
                resourceManager,
                takeDamageEvent);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Create new ShipController
        /// </summary>
        /// <param name="rigidbody">Link to ship Rigidbody</param>
        /// <returns></returns>
        public ShipController CreateShipController(
            Rigidbody rigidbody)
        {
            return new ShipController(
                _createUpdatable,
                _destroyUpdatable,
                rigidbody,
                _takeDamageEvent);
        }

        /// <summary>
        /// Create new FireController
        /// </summary>
        /// <param name="bulletStartPosition">Link to Transform, where bullet was instantiate</param>
        /// <returns></returns>
        public FireController CreateFireController(
            Transform bulletStartPosition)
        {
            return new FireController(
                _createUpdatable,
                _destroyUpdatable,
                bulletStartPosition,
                this,
                _missileControllersFactory);
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
        /// <returns></returns>
        public EnemySpawner CreateEnemySpawner()
        {
            return new EnemySpawner(
                _createUpdatable,
                _destroyUpdatable,
                _enemyControllersFactory,
                this);
        }

        #endregion

    }
}
