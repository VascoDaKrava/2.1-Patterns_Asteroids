using System;


namespace Asteroids
{
    public sealed class CreateUpdatableObjectEvent
    {

        #region Fields / Events

        private event Action<IUpdatable> _createUpdatableObject;

        #endregion


        #region Properties / Subscription and Unsubscription

        public event Action<IUpdatable> CreateUpdatableObject
        {
            add { _createUpdatableObject += value; }
            remove { _createUpdatableObject -= value; }
        }

        #endregion


        #region Methods / Calling

        public void Invoke(IUpdatable obj)
        {
            _createUpdatableObject.Invoke(obj);
        }

        #endregion

    }
}
