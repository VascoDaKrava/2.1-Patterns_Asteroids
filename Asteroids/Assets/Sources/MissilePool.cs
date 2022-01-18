using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public sealed class MissilePool
    {

        private int _poolCapacity = 10;

        private Stack<MissileController> _missiles;

        public MissilePool(
            UpdatableControllersFactory controllersFactory,
            ResourceManager resourceManager,
            Transform bulletStartPosition)
        {
            _missiles = new Stack<MissileController>(_poolCapacity);
            for (int i = 0; i < _poolCapacity; i++)
            {
                _missiles.Push(controllersFactory.CreateMissileController(resourceManager, bulletStartPosition));
            }
        }

        public void Pop(Transform position, Vector3 direction)
        {

        }

        public void Push()
        {

        }

        private void MakeMissileInactive(MissileController missile)
        {
            //missile.
        }
    }
}
