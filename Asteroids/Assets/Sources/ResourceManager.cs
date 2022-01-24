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

        public GameObject MissileAIM9 => Resources.Load(ResourcesPath.MISSILE_AIM9) as GameObject;

        public GameObject Asteroid => Resources.Load(ResourcesPath.ASTEROID) as GameObject;

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

    }
}
