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
            _missileRigidbody.velocity = _missileRigidbody.gameObject.transform.forward * _missileModel.Speed;
        }

        public override void LetUpdate()
        {
            MissileFly();
        }

        #endregion

    }
}
