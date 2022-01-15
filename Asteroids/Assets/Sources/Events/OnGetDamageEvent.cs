using System;

namespace Asteroids
{
    public sealed class OnGetDamageEvent
    {

        #region Fields / Events

        private event Action<int> _onGetDamage;

        #endregion


        #region Properties / Subscription and Unsubscription

        public event Action<int> OnGetDamage
        {
            add { _onGetDamage += value; }
            remove { _onGetDamage -= value; }
        }

        #endregion


        #region Methods / Calling

        public void Invoke(int value)
        {
            _onGetDamage.Invoke(value);
        }

        #endregion
    }
}
