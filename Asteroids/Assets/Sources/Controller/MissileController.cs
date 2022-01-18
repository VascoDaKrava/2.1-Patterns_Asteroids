using UnityEngine;


namespace Asteroids
{
    public sealed class MissileController : UpdatableObject, IPoolable
    {

        #region Fields

        private MissileModel _missileModel;
        private MissileView _missileView;
        private Rigidbody _missileRigidbody;

        #endregion


        #region ClassLifeCicles

        public MissileController(
            CreateUpdatableObjectEvent createUpdatableObject,
            DestroyUpdatableObjectEvent destroyUpdatableObject,
            ResourceManager resourceManager,
            Transform bulletStartPosition) :
            base(createUpdatableObject, destroyUpdatableObject)
        {
            _missileModel = new MissileModel();

            _missileView = GameObject.Instantiate(
                resourceManager.MissileAIM9,
                bulletStartPosition.position,
                bulletStartPosition.rotation).GetComponent<MissileView>();

            _missileRigidbody = _missileView.gameObject.GetComponent<Rigidbody>();

            _missileView.Damage = _missileModel.Damage;
        }

        #endregion


        #region Methods

        private void MissileFly()
        {
            if (_missileRigidbody != null)
            {
                _missileRigidbody.velocity = _missileRigidbody.gameObject.transform.forward * _missileModel.Speed;
            }
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            MissileFly();
        }

        #endregion


        #region IPoolable

        public void PrepareForPop()
        {
            
        }

        public void PrepareForPush()
        {
            _missileRigidbody.gameObject.SetActive(false);
            RemoveFromUpdate();
        }

        #endregion

    }
}
