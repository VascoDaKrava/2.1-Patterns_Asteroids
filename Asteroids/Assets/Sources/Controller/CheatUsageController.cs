using UnityEngine;


namespace Asteroids
{
    public sealed class CheatUsageController : UpdatableObject
    {

        #region Fields

        private PauseMenuHandlers _pauseMenu;
        private Transform _playerShip;

        #endregion


        #region ClassLifeCycles

        public CheatUsageController(
            CreateUpdatableObjectEvent createUpdatableObject,
            DestroyUpdatableObjectEvent destroyUpdatableObject,
            PauseMenuHandlers pauseMenu,
            Transform playerShip) : base(createUpdatableObject, destroyUpdatableObject)
        {
            _pauseMenu = pauseMenu;
            _playerShip = playerShip;
        }

        #endregion


        #region Methods

        private void UseKillEnemyCheat()
        {
            if (InputManager.isCheat && _pauseMenu.IsCheatsOn)
            {
                if (Sonar.StartSonar(_playerShip.position, float.MaxValue, out Transform target))
                {
                    Debug.Log("CHEAT " + target.name);
                }
            }
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            UseKillEnemyCheat();
        }

        #endregion

    }
}
