using UnityEngine;


namespace Asteroids
{
    public sealed class EnemyShipController : EnemyController, IEnemyPoolable
    {

        #region Properties

        public EnemyModel EnemyModel
        {
            get => _enemyModel;

            set
            {
                _enemyModel = value;
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

        public EnemyShipController(
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
            _enemyModel.ArmorEnemyShip -= value;
            if (_enemyModel.ArmorEnemyShip <= 0)
            {
                _enemyModel.Strength += _enemyModel.ArmorEnemyShip;
                _enemyModel.ArmorEnemyShip = 0;
                if (_enemyModel.Strength <= 0)
                {
                    Hit();
                }
            }
        }

        protected override void Hit()
        {
            ReturnToPool(_enemyPool, this);
        }

        #endregion

    }
}
