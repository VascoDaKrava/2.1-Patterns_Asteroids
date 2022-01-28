using UnityEngine;


namespace Asteroids
{
    public interface IPoolable
    {

        #region Properties

        /// <summary>
        /// Set pool to returning
        /// </summary>
        public MissilePool SetMissilePool { set; get; }

        #endregion


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
        public void PrepareBeforePush();

        /// <summary>
        /// Return missile to pool
        /// </summary>
        /// <param name="missilePool"></param>
        /// <param name="lineMissile"></param>
        public void ReturnToPool(MissilePool missilePool, LineMissileController lineMissile);

        #endregion

    }
}
