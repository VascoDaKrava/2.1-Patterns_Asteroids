using System;
using UnityEngine;


namespace Asteroids
{
    public sealed class CollisionDetectorEvent
    {

        #region Fields / Events

        private event Action<Transform, Transform> _collisionDetector;

        #endregion


        #region Properties / Subscription and Unsubscription

        public event Action<Transform, Transform> CollisionDetector
        {
            add { _collisionDetector += value; }
            remove { _collisionDetector -= value; }
        }

        #endregion


        #region Methods / Calling

        public void Invoke(Transform caller, Transform called)
        {
            _collisionDetector?.Invoke(caller, called);
        }

        #endregion

    }
}
