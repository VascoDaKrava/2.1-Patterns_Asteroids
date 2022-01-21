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
            CollisionDetectorEvent collisionDetectorEvent,
            TakeDamageEvent takeDamageEvent,
            Transform target) :
            base(createUpdatableObject, destroyUpdatableObject, resourceManager, bulletStartPosition, bulletStartDirection, collisionDetectorEvent, takeDamageEvent)
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
                if (_missileRigidbody)
                {
                    _missileRigidbody.MoveRotation(Quaternion.LookRotation(_target.position - _missileRigidbody.transform.position));
                    _missileRigidbody.velocity = _missileRigidbody.transform.forward * _missileModel.Speed;
                }
            }
        }

        protected override void Hit()
        {
            Destroy();
        }

        public override void Destroy()
        {
            RemoveFromUpdate();
            base.Destroy();
            if (_missileView)
                _missileView.DestroyMissile();
        }

        #endregion

    }
}
