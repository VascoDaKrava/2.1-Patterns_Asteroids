using UnityEngine;


namespace Asteroids
{
    public sealed class LineMissileController : AbstractMissile, IPoolable
    {

        #region Fields

        private MissilePool _missilePool;

        #endregion


        #region ClassLifeCicles

        public LineMissileController(CreateUpdatableObjectEvent createUpdatableObject,
           DestroyUpdatableObjectEvent destroyUpdatableObject,
           ResourceManager resourceManager,
           Vector3 bulletStartPosition,
           Quaternion bulletStartDirection) :
           base(createUpdatableObject, destroyUpdatableObject, resourceManager, bulletStartPosition, bulletStartDirection)
        {
        }

        #endregion


        #region Methods

        protected override void MissileFly()
        {
            _missileRigidbody.velocity = _missileRigidbody.transform.forward * _missileModel.Speed;
        }

        protected override void CheckHit()
        {
            if (_missileView.IsHit)
            {
                if (_missileView.HittingCollider.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    damageable.GetDamage(_missileModel.Damage);
                }

                PrepareBeforePush(_missilePool);
                _missilePool.Push(this);
            }
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

        public void PrepareBeforePush(MissilePool missilePool)
        {
            if (_missilePool == null) _missilePool = missilePool;
            _missileView.IsHit = false;
            _missileRigidbody.gameObject.SetActive(false);
            RemoveFromUpdate();
        }

        #endregion

    }
}
