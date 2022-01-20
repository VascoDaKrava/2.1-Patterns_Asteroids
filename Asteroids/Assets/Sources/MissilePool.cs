using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public sealed class MissilePool
    {

        #region Fields

        private int _poolCapacity;
        private Stack<LineMissileController> _missiles;

        #endregion


        #region ClassLifeCicles

        public MissilePool(
            UpdatableControllersFactory controllersFactory,
            int poolCapacity)
        {
            _poolCapacity = poolCapacity;
            _missiles = new Stack<LineMissileController>(_poolCapacity);
            for (int i = 0; i < _poolCapacity; i++)
            {
                Push(controllersFactory.CreateMissileController(Vector3.zero, Quaternion.identity));
                _missiles.Peek().PrepareBeforePush(this);
            }
        }

        #endregion


        #region Methods

        public void Pop(Vector3 position, Quaternion direction)
        {
            if (_missiles.Count == 0) return;
            _missiles.Peek().PrepareAfterPop(position, direction);
            _missiles.Pop();
            Debug.Log($"Missiles in pool : {_missiles.Count} / {_poolCapacity}");
        }

        public void Push(LineMissileController missileController)
        {
            _missiles.Push(missileController);
            Debug.Log($"Missiles in pool : {_missiles.Count} / {_poolCapacity}");
        }

        #endregion

    }
}
