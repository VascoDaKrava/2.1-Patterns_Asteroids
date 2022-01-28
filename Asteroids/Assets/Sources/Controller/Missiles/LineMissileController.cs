using UnityEngine;


namespace Asteroids
{
    public sealed class LineMissileController : AbstractMissile, IPoolable
    {

        #region Fields

        private MissilePool _missilePool;

        #endregion


        #region Properties

        public MissilePool SetMissilePool { set => _missilePool = value; get => _missilePool; }

        #endregion


        #region ClassLifeCicles

        public LineMissileController(CreateUpdatableObjectEvent createUpdatableObject,
           DestroyUpdatableObjectEvent destroyUpdatableObject,
           ResourceManager resourceManager,
           Vector3 bulletStartPosition,
           Quaternion bulletStartDirection,
           CollisionDetectorEvent collisionDetectorEvent,
           TakeDamageEvent takeDamageEvent) : base
           (createUpdatableObject, destroyUpdatableObject, resourceManager, bulletStartPosition, bulletStartDirection, collisionDetectorEvent, takeDamageEvent)
        {
            PrepareBeforePush();
        }

        #endregion


        #region Methods

        protected override void MissileFly()
        {
            _missileRigidbody.velocity = _missileRigidbody.transform.forward * _missileModel.Speed;
        }

        protected override void Hit()
        {
            ReturnToPool(_missilePool, this);
        }

        #endregion


        #region IPoolable

        public void PrepareAfterPop(Vector3 position, Quaternion rotation)
        {
            _missileRigidbody.gameObject.SetActive(true);
            _missileRigidbody.transform.position = position;
            _missileRigidbody.transform.rotation = rotation;
            AddToUpdate();
        }

        public void PrepareBeforePush()
        {
            RemoveFromUpdate();
            _missileRigidbody.gameObject.SetActive(false);
        }

        public void ReturnToPool(MissilePool missilePool, LineMissileController lineMissile)
        {
            PrepareBeforePush();
            missilePool.Push(lineMissile);
        }

        #endregion

    }
}
