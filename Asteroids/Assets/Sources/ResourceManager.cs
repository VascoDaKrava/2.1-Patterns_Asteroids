using UnityEngine;


namespace Asteroids
{
    public sealed class ResourceManager
    {

        #region Fields

        private GameObject _endGame;
        private Canvas _canvas;

        #endregion


        #region Properties

        public GameObject MissileAIM9 => Resources.Load<GameObject>(ResourcesPath.MISSILE_AIM9);

        public GameObject Asteroid => Resources.Load<GameObject>(ResourcesPath.ASTEROID);

        public GameObject LargeAsteroid => Resources.Load<GameObject>(ResourcesPath.LARGE_ASTEROID);

        public GameObject EnemyShip => Resources.Load<GameObject>(ResourcesPath.ENEMY_SHIP);

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject EndGame
        {
            get
            {
                var gameobject = Resources.Load<GameObject>(ResourcesPath.END_GAME);
                _endGame = Object.Instantiate(gameobject, Canvas.transform);

                return _endGame;
            }
                
        }

        #endregion
    }
}
