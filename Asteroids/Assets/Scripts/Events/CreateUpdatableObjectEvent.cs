using System;


namespace Asteroids
{

    public sealed class CreateUpdatableObjectEvent
    {

        private event Action<IUpdatable> _createUpdatableObject;

        public event Action<IUpdatable> CreateUpdatableObject
        {
            add { _createUpdatableObject += value; }
            remove { _createUpdatableObject -= value; }
        }

        public void Invoke(IUpdatable obj)
        {
            _createUpdatableObject.Invoke(obj);
        }

    }
}
