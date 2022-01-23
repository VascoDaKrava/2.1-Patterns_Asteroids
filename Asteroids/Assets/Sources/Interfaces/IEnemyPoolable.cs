using UnityEngine;


namespace Asteroids
{
     public interface IEnemyPoolable
    {

        #region Methods

        /// <summary>
        /// Set position and direction of popped object, make view visible, add to update etc.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        public void PrepareAfterPop(Vector3 position, Quaternion rotation);

        /// <summary>
        /// Make View invisible, remove from update etc.
        /// </summary>
        public void PrepareBeforePush(EnemyPool enemyPool);

        #endregion
    }
}
