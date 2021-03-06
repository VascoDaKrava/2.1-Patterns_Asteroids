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

        public EnemyPool(EnemyControllerFactory enemyControllersFactory,
            int poolCapacity)
        {
            _poolCapacity = poolCapacity;
            _enemies = new Stack<EnemyController>(_poolCapacity);
            for (int i = 0; i < _poolCapacity; i++)
            {
                var randomValue = Random.Range(0.0f, 1.0f);
                
                if (randomValue < _minValueForCreating)
                {
                    var enemy = enemyControllersFactory.CreateSmallAsteroidController();
                    enemy.SetEnemyPool = this;
                    enemy.Controller = enemy;
                    enemy.ReturnToPool();
                }
                else if (randomValue >= _minValueForCreating && randomValue <= _maxValueForCreating)
                {
                    var enemy = enemyControllersFactory.CreateLargeAsteroidController();
                    enemy.SetEnemyPool = this;
                    enemy.Controller = enemy;
                    enemy.ReturnToPool();
                }
                else if (randomValue > _maxValueForCreating)
                {
                    var enemy = enemyControllersFactory.CreateEnemyShipController();
                    enemy.SetEnemyPool = this;
                    enemy.Controller = enemy;
                    enemy.ReturnToPool();
                }
            }
        }

        #endregion


        #region Methods

        public void Pop(Vector3 position, Quaternion rotation)
        {
            if (_enemies.Count == 0) 
            {
                return;
            }
            _enemies.Peek().PrepareAfterPop(position, rotation);
            _enemies.Pop();
        }

        public void Push(EnemyController enemyController)
        {
            _enemies.Push(enemyController);
        }

        #endregion

    }
}
