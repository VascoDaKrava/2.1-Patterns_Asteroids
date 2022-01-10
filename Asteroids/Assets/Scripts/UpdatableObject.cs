namespace Asteroids
{
    /// <summary>
    /// Abstract class for objects, who must use Update
    /// </summary>
    public abstract class UpdatableObject : IUpdatable
    {
        
        #region Fields

        private DestroyUpdatableObjectEvent _destroyUpdatableObject;

        #endregion


        #region ClassLifeCycles

        public UpdatableObject(CreateUpdatableObjectEvent createUpdatableObject, DestroyUpdatableObjectEvent destroyUpdatableObject)
        {
            _destroyUpdatableObject = destroyUpdatableObject;
            createUpdatableObject.Invoke(this);
        }

        // Деструктор, который не вызывается, когда надо...
        //~UpdatableObject()
        //{
        //    _destroyUpdatableObject.Invoke(this);
        //    _gameStarter.RemoveFromUpdateList(this);
        //    Debug.Log($"Destructor : {this}");
        //}

        #endregion


        #region Methods

        internal void RemoveFromUpdate()
        {
            _destroyUpdatableObject.Invoke(this);
        }

        #endregion


        #region IUpdatable

        public abstract void LetUpdate();

        #endregion
    }
}