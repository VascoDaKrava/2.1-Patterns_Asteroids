using UnityEngine;
using UnityEngine.UI;


namespace Asteroids
{
    public sealed class DisplayEndGame
    {
        #region Fields

        private Text _finishGameLabel;
        private Image _background;
        private GameObject _prefab;

        #endregion


        #region ClassLifeCycles

        public DisplayEndGame (GameObject endGame)
        {
            _prefab = endGame;
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _background = endGame.GetComponentInChildren<Image>();
            _finishGameLabel.text = string.Empty;
            _background.gameObject.SetActive(false);
            _prefab.gameObject.SetActive(false);
        }

        #endregion


        #region Methods

        public void GameOver()
        {
            _prefab.gameObject.SetActive(true);
            _finishGameLabel.text = "GAME OVER!";
            _background.gameObject.SetActive(true);
        }

        #endregion
    }
}
