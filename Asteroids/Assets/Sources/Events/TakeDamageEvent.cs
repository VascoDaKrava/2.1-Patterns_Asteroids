using System;
using UnityEngine;


namespace Asteroids
{
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

        public void Invoke(Transform damageReciever, int damage)
        {
            _takeDamageEvent?.Invoke(damageReciever, damage);
        }

        #endregion

    }
}
