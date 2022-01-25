using UnityEngine;


namespace Asteroids
{
    public sealed class DisplayEndGame
    {
        #region Fields

        private GameObject _gameOver;

        #endregion


        #region Methods

        public GameObject GameOver(ResourceManager resourceManager)
        {
            _gameOver = resourceManager.EndGame;
            var endGame = GameObject.Instantiate(_gameOver, resourceManager.Canvas.transform);

            return endGame;
        }

        #endregion
    }
}
