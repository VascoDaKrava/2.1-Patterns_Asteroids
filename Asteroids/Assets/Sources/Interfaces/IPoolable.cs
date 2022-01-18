using UnityEngine;


namespace Asteroids
{
    public interface IPoolable
    {
        public void PrepareAfterPop(Vector3 position, Quaternion rotation);

        public void PrepareBeforePush(MissilePool missilePool);
    }
}
