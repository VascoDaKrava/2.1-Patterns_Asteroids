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

        #endregion


        #region ClassLifeCicles

        public UpdatableControllersFactory(CreateUpdatableObjectEvent createUpdatable, DestroyUpdatableObjectEvent destroyUpdatable)
        {
            _createUpdatable = createUpdatable;
            _destroyUpdatable = destroyUpdatable;
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
        /// <param name="resourceManager">Link to ResourceManager</param>
        /// <param name="updatableControllersFactory">Link to ControllersFactory</param>
        /// <returns></returns>
        public FireController CreateFireController(
            Transform bulletStartPosition,
            InputManager inputManagerLink,
            ResourceManager resourceManager,
            UpdatableControllersFactory updatableControllersFactory)
        {
            return new FireController(
                _createUpdatable,
                _destroyUpdatable,
                bulletStartPosition,
                inputManagerLink,
                resourceManager,
                updatableControllersFactory);
        }

        /// <summary>
        /// Create new MissileController
        /// </summary>
        /// <param name="resourceManager">Link to ResourceManager</param>
        /// <param name="bulletStartPosition">Link to Transform, where bullet was instantiate</param>
        /// <returns></returns>
        public MissileController CreateMissileController(
            ResourceManager resourceManager,
            Transform bulletStartPosition)
        {
            return new MissileController(
                _createUpdatable,
                _destroyUpdatable,
                resourceManager,
                bulletStartPosition);
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
        /// <param name="resourceManager">Link to ResourceManager</param>
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
                spawnPosition,
                resourceManager,
                controllersFactory);
        }

        /// <summary>
        /// Create new AsteroidController
        /// </summary>
        /// <param name="resourceManager">Link to ResourceManager</param>
        /// <param name="spawnPosition">Link to Transform, where Enemy was instantiate</param>
        /// <returns></returns>
        public AsteroidController CreateAsteroidController(
            ResourceManager resourceManager,
            Transform spawnPosition)
        {
            return new AsteroidController(
                _createUpdatable,
                _destroyUpdatable,
                resourceManager,
                spawnPosition);
        }

        #endregion

    }
}
