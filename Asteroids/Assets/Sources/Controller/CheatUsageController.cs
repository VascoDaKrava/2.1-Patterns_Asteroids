using UnityEngine;


namespace Asteroids
{
    public sealed class CheatUsageController : UpdatableObject
    {

        #region Fields

        private PauseMenuHandlers _pauseMenu;
        private TakeDamageEvent _takeDamageEvent;
        private Transform _playerShip;

        #endregion


        #region ClassLifeCycles

        public CheatUsageController(
            CreateUpdatableObjectEvent createUpdatableObject,
            DestroyUpdatableObjectEvent destroyUpdatableObject,
            PauseMenuHandlers pauseMenu,
            Transform playerShip,
            TakeDamageEvent takeDamageEvent) : base(createUpdatableObject, destroyUpdatableObject)
        {
            _pauseMenu = pauseMenu;
            _takeDamageEvent = takeDamageEvent;
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
                    _takeDamageEvent.Invoke(target, int.MaxValue);
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
