using UnityEngine;
using Random = UnityEngine.Random;


namespace Asteroids
{
    public abstract class EnemyController : UpdatableObject, IPoolable
    {

        #region Fields

        protected EnemyView _enemyView;
        protected EnemyModel _enemyModel;
        protected Rigidbody _enemyRigidbody;
        protected Vector3 _direction;
        protected EnemyFactory _enemyFactory;
        protected EnemyPool _enemyPool;

        private float _minDirectionX = -0.7f;
        private float _maxDirectionX = 0.7f;
        private float _minDirectionZ = 0.0f;
        private float _maxDirectionZ = -1.0f;

        #endregion


        #region ClassLifeCycles

        public EnemyController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent) :
            base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _enemyFactory = new EnemyFactory();

            _direction = new Vector3(Random.Range(_minDirectionX, _maxDirectionX),
                0.0f, Random.Range(_minDirectionZ, _maxDirectionZ));

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

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            EnemyFly();
        }

        #endregion


        #region IPoolable

        public void PrepareAfterPop(Vector3 position, Quaternion rotation)
        {
            if (_enemyRigidbody != null)
            {
                _enemyRigidbody.gameObject.SetActive(true);
                _enemyRigidbody.transform.position = position;
                _enemyRigidbody.transform.rotation = rotation;
                AddToUpdate();
            }
        }

        public void PrepareBeforePush(EnemyPool enemyPool)
        {
            if (_enemyPool == null)
            {
                _enemyPool = enemyPool;
            }

            if (_enemyRigidbody != null)
            {
                _enemyRigidbody.gameObject.SetActive(false);
                RemoveFromUpdate();
            }
        }

        #endregion

    }
}
