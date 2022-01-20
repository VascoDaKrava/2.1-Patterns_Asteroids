using UnityEngine;


namespace Asteroids
{
    public sealed class HomingMissileController : AbstractMissile
    {

        #region Fields

        private Transform _target;

        #endregion


        #region ClassLifeCicles

        public HomingMissileController(CreateUpdatableObjectEvent createUpdatableObject,
            DestroyUpdatableObjectEvent destroyUpdatableObject,
            ResourceManager resourceManager,
            Vector3 bulletStartPosition,
            Quaternion bulletStartDirection,
            Transform target) :
            base(createUpdatableObject, destroyUpdatableObject, resourceManager, bulletStartPosition, bulletStartDirection)
        {
            _target = target;
        }

        #endregion


        #region Methods

        protected override void MissileFly()
        {
            Debug.Log("Target " + _target);
            if (_target == null)
                Destroy();
            else
            {
                _missileRigidbody.MoveRotation(Quaternion.LookRotation(_target.position - _missileRigidbody.transform.position));
                _missileRigidbody.velocity = _missileRigidbody.transform.forward * _missileModel.Speed;
            }
        }

        protected override void CheckHit()
        {
            if (_missileView.IsHit)
            {
                if (_missileView.HittingCollider.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    damageable.GetDamage(_missileModel.Damage);
                }
                Destroy();
            }
        }

        private void Destroy()
        {
            _missileView.Destroy();
            RemoveFromUpdate();
        }

        #endregion

    }
}
