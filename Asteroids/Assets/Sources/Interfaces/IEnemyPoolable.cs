using UnityEngine;


namespace Asteroids
{
     public interface IEnemyPoolable
    {

        #region Properties

        public EnemyPool SetEnemyPool { set; get; }

        #endregion


        #region Methods

        public void PrepareAfterPop(Vector3 position, Quaternion rotation);

        public void PrepareBeforePush();

        public void ReturnToPool(EnemyPool enemyPool, EnemyController enemyController);

        public void ReturnToPoolInTime();

        #endregion

    }
}
