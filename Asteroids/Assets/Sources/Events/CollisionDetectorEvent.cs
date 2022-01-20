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

        private event Action<Collider, Collider> _collisionDetector;

        #endregion


        #region Properties / Subscription and Unsubscription

        public event Action<Collider, Collider> CollisionDetector
        {
            add { _collisionDetector += value; }
            remove { _collisionDetector -= value; }
        }

        #endregion


        #region Methods / Calling

        /// <summary>
        /// Invoke CollisionDetector event
        /// </summary>
        /// <param name="caller">Collider, who invoke event</param>
        /// <param name="called">Collider, who make collision with caller</param>
        public void Invoke(Collider caller, Collider called)
        {
            _collisionDetector?.Invoke(caller, called);
        }

        #endregion

    }
}
