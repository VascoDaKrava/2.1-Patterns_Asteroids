using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public sealed class MissilePool
    {

        private int _poolCapacity;

        private Stack<MissileController> _missiles;

        public MissilePool(
            UpdatableControllersFactory controllersFactory,
            ResourceManager resourceManager,
            int poolCapacity)
        {
            _poolCapacity = poolCapacity;
            _missiles = new Stack<MissileController>(_poolCapacity);
            for (int i = 0; i < _poolCapacity; i++)
            {
                Push(controllersFactory.CreateMissileController(resourceManager, Vector3.zero, Quaternion.identity));
                _missiles.Peek().PrepareBeforePush(this);
            }
        }

        public void Pop(Vector3 position, Quaternion direction)
        {
            if (_missiles.Count == 0) return;
            _missiles.Peek().PrepareAfterPop(position, direction);
            _missiles.Pop();
            Debug.Log($"Bullets left : {_missiles.Count} / {_poolCapacity}");
        }

        public void Push(MissileController missileController)
        {
            _missiles.Push(missileController);
            Debug.Log($"Bullets left : {_missiles.Count} / {_poolCapacity}");
        }
    }
}
