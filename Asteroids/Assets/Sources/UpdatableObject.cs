namespace Asteroids
{
    /// <summary>
    /// Abstract class for objects, who must use Update
    /// </summary>
    public abstract class UpdatableObject : IUpdatable
    {
        
        #region Fields

        private DestroyUpdatableObjectEvent _destroyUpdatableObjectEvent;
        private CreateUpdatableObjectEvent _createUpdatableObjectEvent;

        #endregion


        #region ClassLifeCycles

        public UpdatableObject(CreateUpdatableObjectEvent createUpdatableObject, DestroyUpdatableObjectEvent destroyUpdatableObject)
        {
            _destroyUpdatableObjectEvent = destroyUpdatableObject;
            _createUpdatableObjectEvent = createUpdatableObject;
            AddToUpdate();
        }

        #endregion


        #region Methods

        internal void RemoveFromUpdate()
        {
            _destroyUpdatableObjectEvent.Invoke(this);
        }

        internal void AddToUpdate()
        {
            _createUpdatableObjectEvent.Invoke(this);
        }

        #endregion


        #region IUpdatable

        public abstract void LetUpdate();

        #endregion

    }
}