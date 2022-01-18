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

        private void MissileFly()
        {
            if (_missileRigidbody != null)
            {
                _missileRigidbody.velocity = _missileRigidbody.gameObject.transform.forward * _missileModel.Speed;
            }
        }

        private void CheckHit()
        {
            if (_missileView.IsHit)
            {
                if (_missileView.HittingCollider.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    damageable.GetDamage(_missileModel.Damage);
                }
                
                PrepareBeforePush();
            }
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            MissileFly();
            CheckHit();
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
            _missileView.IsHit = false;
            _missileRigidbody.gameObject.SetActive(false);
            RemoveFromUpdate();
        }

        #endregion

    }
}
