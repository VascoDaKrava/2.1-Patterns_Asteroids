using System;


namespace Asteroids
{

    public sealed class DestroyUpdatableObjectEvent
    {

        private event Action<IUpdatable> _destroyUpdatableObject;

        public event Action<IUpdatable> DestroyUpdatableObject
        {
            add { _destroyUpdatableObject += value; }
            remove { _destroyUpdatableObject -= value; }
        }

        public void Invoke(IUpdatable obj)
        {
            _destroyUpdatableObject.Invoke(obj);
        }

    }
}
