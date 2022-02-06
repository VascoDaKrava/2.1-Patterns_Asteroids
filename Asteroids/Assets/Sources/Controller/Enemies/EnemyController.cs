using UnityEngine;
using Random = UnityEngine.Random;


namespace Asteroids
{
    public abstract class EnemyController : UpdatableObject, IEnemyPoolable
    {

        #region Fields

        protected EnemyView _enemyView;
        protected EnemyModel _enemyModel;
        protected Rigidbody _enemyRigidbody;
        protected Vector3 _direction;
        protected EnemyPool _enemyPool;
        protected Timers _timers;

        protected CollisionDetectorEvent _collisionDetectorEvent;
        private TakeDamageEvent _takeDamageEvent;

        private float _minDirectionX = -0.7f;
        private float _maxDirectionX = 0.7f;
        private float _minDirectionZ = 0.0f;
        private float _maxDirectionZ = -1.0f;

        #endregion


        #region Proprties

        public EnemyPool SetEnemyPool
        {
            get => _enemyPool;

            set => _enemyPool = value;
        }

        #endregion


        #region ClassLifeCycles

        public EnemyController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            CollisionDetectorEvent collisionDetectorEvent,
            TakeDamageEvent takeDamageEvent) : base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _timers = new Timers(createUpdatableObjectEvent, destroyUpdatableObjectEvent);

            _collisionDetectorEvent = collisionDetectorEvent;
            _takeDamageEvent = takeDamageEvent;

            _direction = new Vector3(Random.Range(_minDirectionX, _maxDirectionX),
                0.0f, Random.Range(_minDirectionZ, _maxDirectionZ));

            _collisionDetectorEvent.CollisionDetector += CollisionEventHandler;
            _takeDamageEvent.TakeDamage += TakeDamageEventHandler;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Moving asteroid in given direction
        /// </summary>
        protected abstract void EnemyFly();

        /// <summary>
        /// Changing asteroid strength from missile damage
        /// </summary>
        /// <param name="value"></param>
        protected abstract void ChangeStrength(int value);

        protected abstract void Hit();

        private void CollisionEventHandler(Transform caller, Transform called)
        {
            if (caller.TryGetComponent(out EnemyView callerView))
            {
                if (callerView == _enemyView)
                {
                    _takeDamageEvent.Invoke(called, _enemyModel.Damage);

                    if (called.CompareTag(TagsAndLayers.PLAYER_TAG))
                    {
                        Hit();
                    }

                }
            }
        }

        private void TakeDamageEventHandler(Transform damageReciever, int damage)
        {
            if (damageReciever.TryGetComponent(out EnemyView damageRecieverView))
            {
                if (damageRecieverView == _enemyView)
                {
                    ChangeStrength(damage);
                }
            }
        }

        public virtual void Destroy()
        {
            _collisionDetectorEvent.CollisionDetector -= CollisionEventHandler;
            _takeDamageEvent.TakeDamage -= TakeDamageEventHandler;
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            EnemyFly();
            ReturnToPoolInTime();
        }

        #endregion


        #region IEnemyPoolable

        public void PrepareAfterPop(Vector3 position, Quaternion rotation)
        {
            _enemyRigidbody.gameObject.SetActive(true);
            _enemyRigidbody.transform.position = position;
            _enemyRigidbody.transform.rotation = rotation;
            AddToUpdate();
            _enemyView.gameObject.GetComponentInChildren<TrailRenderer>().enabled = true;
        }

        public void PrepareBeforePush()
        {
            _enemyView.gameObject.GetComponentInChildren<TrailRenderer>().enabled = false;
            RemoveFromUpdate();
            _enemyRigidbody.gameObject.SetActive(false);
        }

        public void ReturnToPool(EnemyPool enemyPool, EnemyController enemyController)
        {
            PrepareBeforePush();
            enemyPool.Push(enemyController);
        }

        public void ReturnToPoolInTime()
        {
            if (!_timers.isTimerOn)
            {
                _timers.StartTimer(_enemyModel.DeathTime);
                PrepareBeforePush();
                _enemyPool.Push(this);
            }
        }

        #endregion

    }
}
