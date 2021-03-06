using UnityEngine;


namespace Asteroids
{
    public sealed class AsteroidController : EnemyController, IEnemyPoolable
    {

        #region Properties

        public EnemyModel EnemyModel
        {
            get => _enemyModel;

            set
            {
                _enemyModel = value;
                SaveModelData();
            }
        }

        public EnemyView EnemyView
        {
            set
            {
                _enemyView = value;
                _enemyRigidbody = _enemyView.gameObject.GetComponent<Rigidbody>();
                _enemyView.CollisionDetectorEvent = _collisionDetectorEvent;
            }
        }

        #endregion


        #region ClassLifeCycles

        public AsteroidController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            CollisionDetectorEvent collisionDetectorEvent,
            TakeDamageEvent takeDamageEvent) : base(createUpdatableObjectEvent, destroyUpdatableObjectEvent, collisionDetectorEvent, takeDamageEvent)
        {
        }

        #endregion


        #region Methods

        protected override void EnemyFly()
        {
            if (_enemyRigidbody != null)
            {
                _enemyRigidbody.velocity = _direction * _enemyModel.Speed;
            }
        }

        protected override void ChangeStrength(int value)
        {
            _enemyModel.Strength -= value;
            if (_enemyModel.Strength <= 0)
            {
                Hit();
            }
        }

        protected override void Hit()
        {
            ReturnToPool();
        }

        #endregion

    }
}
