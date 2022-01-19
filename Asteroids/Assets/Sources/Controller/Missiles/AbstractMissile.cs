using UnityEngine;


namespace Asteroids
{
    public abstract class AbstractMissile : UpdatableObject
    {
        #region Fields

        protected MissileModel _missileModel;
        protected MissileView _missileView;
        protected Rigidbody _missileRigidbody;

        #endregion


        #region ClassLifeCicles

        public AbstractMissile(
            CreateUpdatableObjectEvent createUpdatableObject,
            DestroyUpdatableObjectEvent destroyUpdatableObject,
            ResourceManager resourceManager,
            Vector3 bulletStartPosition,
            Quaternion bulletStartDirection) :
            base(createUpdatableObject, destroyUpdatableObject)
        {
            _missileModel = new MissileModel();

            _missileView = GameObject.Instantiate(
                resourceManager.MissileAIM9,
                bulletStartPosition,
                bulletStartDirection).GetComponent<MissileView>();

            _missileRigidbody = _missileView.gameObject.GetComponent<Rigidbody>();
        }

        #endregion

        #region Methods

        protected abstract void MissileFly();
                
        #endregion

    }
}
