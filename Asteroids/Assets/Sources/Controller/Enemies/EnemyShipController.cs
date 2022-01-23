using System;
using UnityEngine;


namespace Asteroids
{
    public sealed class EnemyShipController : EnemyController, IDisposable
    {

        #region Fields

        private CollisionDetectorEvent _collisionDetectorEvent;
        private TakeDamageEvent _takeDamageEvent;

        #endregion


        #region Properties

        public EnemyView EnemyView
        {
            set
            {
                _enemyView = value;
                _enemyRigidbody = _enemyView.gameObject.GetComponent<Rigidbody>();
                _enemyView.DestroyEnemyTime(_enemyModel.DeathTime);
                _enemyView.CollisionDetectorEvent = _collisionDetectorEvent;
            }
        }

        #endregion


        #region ClassLifeCycles

        public EnemyShipController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            ResourceManager resourceManager,
            Transform spawnPosition,
            CollisionDetectorEvent collisionDetectorEvent,
            TakeDamageEvent takeDamageEvent) :
            base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _enemyModel = new EnemyShipModel();

            _collisionDetectorEvent = collisionDetectorEvent;
            _takeDamageEvent = takeDamageEvent;

            _collisionDetectorEvent.CollisionDetector += CollisionEventHandler;
            _takeDamageEvent.TakeDamage += TakeDamageEventHandler;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Moving asteroid in given direction
        /// </summary>
        protected override void EnemyFly()
        {
            if (_enemyRigidbody != null)
            {
                _enemyRigidbody.velocity =
                    _direction *
                    _enemyModel.Speed;
            }
        }

        /// <summary>
        /// Changing asteroid strength from missile damage
        /// </summary>
        /// <param name="value"></param>
        protected override void ChangeStrength(int value)
        {
            _enemyModel.Strength -= value;
            if (_enemyModel.Strength <= 0)
            {
                _enemyModel.Strength -= value;
                if (_enemyModel.Strength <= 0)
                {
                    PrepareBeforePush(_enemyPool);
                    _enemyPool.Push(this);
                    //Dispose();
                }
            }
        }

        private void CollisionEventHandler(Transform caller, Transform called)
        {
            if (caller.TryGetComponent(out EnemyView callerView))
            {
                if (callerView == _enemyView)
                {
                    _takeDamageEvent.Invoke(called, _enemyModel.Damage);

                    //if (called.CompareTag(TagsAndLayers.PLAYER_TAG))
                    //    Dispose();
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

        #endregion


        #region IDisposable

        public void Dispose()
        {
            //_enemyView.DestroyEnemy();

            _collisionDetectorEvent.CollisionDetector -= CollisionEventHandler;
            _takeDamageEvent.TakeDamage -= TakeDamageEventHandler;

            RemoveFromUpdate();
        }

        #endregion
    }
}
