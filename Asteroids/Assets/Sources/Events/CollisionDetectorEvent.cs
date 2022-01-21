using System;
using UnityEngine;


namespace Asteroids
{
    /// <summary>
    /// Event, that is invoked when somebody make collision (for example, OnTriggerEnter)
    /// </summary>
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

        /// <summary>
        /// Invoke CollisionDetector event
        /// </summary>
        /// <param name="caller">Transform of GameObject, who invoke event</param>
        /// <param name="called">Transform of GameObject, who make collision with caller</param>
        public void Invoke(Transform caller, Transform called)
        {
            _collisionDetector?.Invoke(caller, called);
        }

        #endregion

    }
}
