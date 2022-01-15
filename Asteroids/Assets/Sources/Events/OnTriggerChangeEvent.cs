using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class OnTriggerChangeEvent
    {

        #region Fields / Events

        private event Action<GameObject> _onTriggerChange;

        #endregion


        #region Properties / Subscription and Unsubscription

        public event Action<GameObject> OnTriggerChange
        {
            add { _onTriggerChange += value; }
            remove { _onTriggerChange -= value; }
        }

        #endregion


        #region Methods / Calling

        public void Invoke(GameObject obj)
        {
            _onTriggerChange.Invoke(obj);
        }

        #endregion

    }
}
