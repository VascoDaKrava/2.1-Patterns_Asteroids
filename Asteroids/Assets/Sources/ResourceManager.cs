using UnityEngine;


namespace Asteroids
{
    public sealed class ResourceManager
    {

        #region Fields

        private GameObject _endGame;
        private Canvas _canvas;

        #endregion

<<<<<<< HEAD

=======
>>>>>>> 3.6-GameLose
        #region Properties

        public GameObject MissileAIM9 => Resources.Load<GameObject>(ResourcesPath.MISSILE_AIM9);

        public GameObject Asteroid => Resources.Load<GameObject>(ResourcesPath.ASTEROID);

<<<<<<< HEAD
        public GameObject LargeAsteroid => Resources.Load<GameObject>(ResourcesPath.LARGE_ASTEROID);
=======
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

        public GameObject EndGame => Resources.Load(ResourcesPath.END_GAME) as GameObject;
        

        #endregion
>>>>>>> 3.6-GameLose

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

        public GameObject EndGame => Resources.Load<GameObject>(ResourcesPath.END_GAME);
        

        #endregion
    }
}
