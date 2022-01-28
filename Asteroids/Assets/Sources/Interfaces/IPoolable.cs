using UnityEngine;


namespace Asteroids
{
    public interface IPoolable
    {

        #region Properties

        public MissilePool SetMissilePool { set; get; }

        #endregion


        #region Methods

        public void PrepareAfterPop(Vector3 position, Quaternion rotation);

        public void PrepareBeforePush();

        public void ReturnToPool(MissilePool missilePool, LineMissileController lineMissile);

        #endregion

    }
}
