namespace Asteroids
{
    /// <summary>
    /// Abstract class for objects, who must use Update
    /// </summary>
    public abstract class UpdatableObject : IUpdatable
    {
        
        #region Fields

        private GameStarter _gameStarter;

        #endregion


        #region ClassLifeCycles

        public UpdatableObject(GameStarter gameStarterLink)
        {
            _gameStarter = gameStarterLink;
            _gameStarter.AddToUpdateList(this);
        }

        ~UpdatableObject()
        {
            _gameStarter.RemoveFromUpdateList(this);
        }

        #endregion


        #region IUpdatable

        public abstract void LetUpdate();

        #endregion
    }
}