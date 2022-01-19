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

        #endregion


        #region ClassLifeCicles

        public UpdatableControllersFactory(CreateUpdatableObjectEvent createUpdatable, DestroyUpdatableObjectEvent destroyUpdatable, ResourceManager resourceManager)
        {
            _createUpdatable = createUpdatable;
            _destroyUpdatable = destroyUpdatable;
            _resourceManager = resourceManager;
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
                rigidbody);
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
                updatableControllersFactory);
        }

        /// <summary>
        /// Create new MissileController
        /// </summary>
        /// <param name="bulletStartPosition">Position, where bullet was instantiate</param>
        /// <param name="bulletStartDirection">Direction of bullet, when it was instantiate</param>
        /// <returns></returns>
        public MissileController CreateMissileController(
            Vector3 bulletStartPosition,
            Quaternion bulletStartDirection)
        {
            return new MissileController(
                _createUpdatable,
                _destroyUpdatable,
                _resourceManager,
                bulletStartPosition,
                bulletStartDirection);
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
            UpdatableControllersFactory controllersFactory)
        {
            return new EnemySpawner(
                _createUpdatable,
                _destroyUpdatable,
                spawnPosition,
                controllersFactory);
        }

        /// <summary>
        /// Create new AsteroidController
        /// </summary>
        /// <param name="spawnPosition">Link to Transform, where Enemy was instantiate</param>
        /// <returns></returns>
        public AsteroidController CreateAsteroidController(
            Transform spawnPosition)
        {
            return new AsteroidController(
                _createUpdatable,
                _destroyUpdatable,
                _resourceManager,
                spawnPosition);
        }

        #endregion

    }
}
