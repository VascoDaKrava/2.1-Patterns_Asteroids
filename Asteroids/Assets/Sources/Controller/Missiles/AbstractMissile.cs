using UnityEngine;


namespace Asteroids
{
    public abstract class AbstractMissile : UpdatableObject
    {

        #region Fields

        protected MissileModel _missileModel;
        protected MissileView _missileView;
        protected Rigidbody _missileRigidbody;
        private CollisionDetectorEvent _collisionDetectorEvent;
        private TakeDamageEvent _takeDamageEvent;

        #endregion


        #region ClassLifeCicles

        public AbstractMissile(
            CreateUpdatableObjectEvent createUpdatableObject,
            DestroyUpdatableObjectEvent destroyUpdatableObject,
            ResourceManager resourceManager,
            Vector3 bulletStartPosition,
            Quaternion bulletStartDirection,
            CollisionDetectorEvent collisionDetectorEvent,
            TakeDamageEvent takeDamageEvent) :
            base(createUpdatableObject, destroyUpdatableObject)
        {
            _collisionDetectorEvent = collisionDetectorEvent;
            _takeDamageEvent = takeDamageEvent;

            _missileModel = new MissileModel();

            _missileView = GameObject.Instantiate(
                resourceManager.MissileAIM9,
                bulletStartPosition,
                bulletStartDirection).GetComponent<MissileView>();

            _missileView.CollisionDetectorEvent = _collisionDetectorEvent;

            _missileRigidbody = _missileView.gameObject.GetComponent<Rigidbody>();

            _collisionDetectorEvent.CollisionDetector += CollisionEventHandler;
        }

        #endregion


        #region Methods

        protected abstract void MissileFly();

        protected abstract void Hit();

        private void CollisionEventHandler(Transform caller, Transform called)
        {
            if (caller.TryGetComponent(out MissileView callerView))
            {
                if (callerView == _missileView)
                {
                    _takeDamageEvent.Invoke(called, _missileModel.Damage);
                    Hit();
                }
            }
        }

        public virtual void Destroy()
        {
            _collisionDetectorEvent.CollisionDetector -= CollisionEventHandler;
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            MissileFly();
        }

        #endregion

    }
}
