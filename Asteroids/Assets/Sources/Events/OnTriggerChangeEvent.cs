using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class OnTriggerChangeEvent
    {

        #region Fields / Events

        private event Action<GameObject, GameObject> _onTriggerChange;

        #endregion


        #region Properties / Subscription and Unsubscription

        public event Action<GameObject, GameObject> OnTriggerChange
        {
            add { _onTriggerChange += value; }
            remove { _onTriggerChange -= value; }
        }

        #endregion


        #region Methods / Calling

        public void Invoke(GameObject attacked, GameObject attack)
        {
            _onTriggerChange.Invoke(attacked, attack);
        }

        #endregion

    }
}
