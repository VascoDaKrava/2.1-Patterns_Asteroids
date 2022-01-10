using System;


namespace Asteroids
{

    /// <summary>
    /// Event, that is invoked when updatable object was destroyed
    /// </summary>
    public sealed class DestroyUpdatableObjectEvent
    {

        #region Fields / Events

        private event Action<IUpdatable> _destroyUpdatableObject;

        #endregion


        #region Properties / Subscription and Unsubscription

        public event Action<IUpdatable> DestroyUpdatableObject
        {
            add { _destroyUpdatableObject += value; }
            remove { _destroyUpdatableObject -= value; }
        }

        #endregion


        #region Methods / Calling

        public void Invoke(IUpdatable obj)
        {
            _destroyUpdatableObject.Invoke(obj);
        }

        #endregion

    }
}
