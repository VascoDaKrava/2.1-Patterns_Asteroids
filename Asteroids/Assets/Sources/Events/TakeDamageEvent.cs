using System;
using UnityEngine;


namespace Asteroids
{
    /// <summary>
    /// Event, that is invoked after collision and if collision-detector can take damage
    /// </summary>
    public sealed class TakeDamageEvent
    {

        #region Fields / Events

        private event Action<Transform, int> _takeDamageEvent;

        #endregion


        #region Properties / Subscription and Unsubscription

        public event Action<Transform, int> TakeDamage
        {
            add { _takeDamageEvent += value; }
            remove { _takeDamageEvent -= value; }
        }

        #endregion


        #region Methods / Calling

        /// <summary>
        /// Invoke event, when damage can transmitted onto damageReciever
        /// </summary>
        /// <param name="damageReciever"></param>
        /// <param name="damage"></param>
        public void Invoke(Transform damageReciever, int damage)
        {
            _takeDamageEvent?.Invoke(damageReciever, damage);
        }

        #endregion

    }
}
