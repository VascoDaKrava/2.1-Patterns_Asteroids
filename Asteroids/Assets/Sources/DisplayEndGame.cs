using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids
{
    public sealed class DisplayEndGame
    {
        #region Fields

        private GameObject _gameOver;
        private float _timeOpenMainMenu = 3.0f;
        private Timers _timers;

        #endregion


        #region ClassLifeCycles

        public DisplayEndGame(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent)
        {
            _timers = new Timers(createUpdatableObjectEvent, destroyUpdatableObjectEvent);
        }

        #endregion


        #region Methods

        public GameObject GameOver(ResourceManager resourceManager)
        {
            _gameOver = resourceManager.EndGame;
            var endGame = GameObject.Instantiate(_gameOver, resourceManager.Canvas.transform);

            return endGame;
        }

        public void GoToMainMenu()
        {
            _timers.StartTimer(_timeOpenMainMenu);
            SceneManager.LoadScene(1);
        }

        #endregion

    }
}
