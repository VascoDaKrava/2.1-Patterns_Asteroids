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

<<<<<<< main
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
>>>>>>> Created GameLose

        public GameObject EnemyShip => Resources.Load<GameObject>(ResourcesPath.ENEMY_SHIP);
      
        #endregion
    }
}
