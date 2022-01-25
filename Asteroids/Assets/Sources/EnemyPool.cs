using UnityEngine;
using System.Collections.Generic;


namespace Asteroids
{
    public sealed class EnemyPool
    {

        #region Fields

        private int _poolCapacity;
        private Stack<EnemyController> _enemies;
        private float _minValueForCreating = 0.6f;
        private float _maxValueForCreating = 0.8f;

        #endregion


        #region ClassLifeCycles

        public EnemyPool(UpdatableControllersFactory controllersFactory,
            ResourceManager resourceManager,
            Transform spawnPosition,
            int poolCapacity)
        {
            _poolCapacity = poolCapacity;
            _enemies = new Stack<EnemyController>(_poolCapacity);
            for (int i = 0; i < _poolCapacity; i++)
            {
                var randomValue = Random.Range(0.0f, 1.0f);
                
                if (randomValue < _minValueForCreating)
                {
                    Push(controllersFactory.CreateSmallAsteroidController(resourceManager, spawnPosition));
                }
                else if (randomValue >= _minValueForCreating && randomValue <= _maxValueForCreating)
                {
                    Push(controllersFactory.CreateLargeAsteroidController(resourceManager, spawnPosition));
                }
                else if (randomValue > _maxValueForCreating)
                {
                    Push(controllersFactory.CreateEnemyShipController(resourceManager, spawnPosition));
                }
                
                _enemies.Peek().SetEnemyPool = this;
                _enemies.Peek().ReturnToPoolInTime();
            }
        }

        #endregion


        #region Methods

        public void Pop(Vector3 position, Quaternion rotation)
        {
            if (_enemies.Count == 0) return;
            _enemies.Peek().PrepareAfterPop(position, rotation);
            _enemies.Pop();
            Debug.Log($"Enemies left : {_enemies.Count} / {_poolCapacity}");
        }

        public void Push(EnemyController enemyController)
        {
            _enemies.Push(enemyController);
            Debug.Log($"Enemies left : {_enemies.Count} / {_poolCapacity}");
        }
        #endregion
    }
}
