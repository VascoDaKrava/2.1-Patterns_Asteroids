using UnityEngine;


namespace Asteroids
{
    public sealed class CheatUsageController : UpdatableObject
    {

        #region Fields

        private PauseMenuHandlers _pauseMenu;

        #endregion


        #region ClassLifeCycles

        public CheatUsageController(
            CreateUpdatableObjectEvent createUpdatableObject,
            DestroyUpdatableObjectEvent destroyUpdatableObject,
            PauseMenuHandlers pauseMenu) : base(createUpdatableObject, destroyUpdatableObject)
        {
            _pauseMenu = pauseMenu;
        }

        #endregion


        #region Methods

        private void CheckCheat()
        {
            if (InputManager.isCheat && _pauseMenu.IsCheatsOn)
            {
                Debug.Log("CHEAT");
            }
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            CheckCheat();
        }

        #endregion

    }
}
