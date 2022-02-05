using UnityEngine;


namespace Asteroids
{
    public sealed class MissileControllerFactory
    {

        #region Fields

        private CollisionDetectorEvent _collisionDetectorEvent;
        private CreateUpdatableObjectEvent _createUpdatable;
        private DestroyUpdatableObjectEvent _destroyUpdatable;
        private ResourceManager _resourceManager;
        private TakeDamageEvent _takeDamageEvent;

        #endregion


        #region ClassLifeCycles

        public MissileControllerFactory(
            CollisionDetectorEvent collisionDetectorEvent,
            CreateUpdatableObjectEvent createUpdatable,
            DestroyUpdatableObjectEvent destroyUpdatable,
            ResourceManager resourceManager,
            TakeDamageEvent takeDamageEvent)
        {
            _collisionDetectorEvent = collisionDetectorEvent;
            _createUpdatable = createUpdatable;
            _destroyUpdatable = destroyUpdatable;
            _resourceManager = resourceManager;
            _takeDamageEvent = takeDamageEvent;
        }

        #endregion


        #region Methods

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

        #endregion

    }
}
