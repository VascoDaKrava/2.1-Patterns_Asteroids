using UnityEngine;


namespace Asteroids
{
    public sealed class ResourceManager
    {

        #region Properties

        public GameObject MissileAIM9 => Resources.Load<GameObject>(ResourcesPath.MISSILE_AIM9);

        public GameObject Asteroid => Resources.Load<GameObject>(ResourcesPath.ASTEROID);

        public GameObject LargeAsteroid => Resources.Load<GameObject>(ResourcesPath.LARGE_ASTEROID);

        public GameObject EnemyShip => Resources.Load<GameObject>(ResourcesPath.ENEMY_SHIP);
      
        public GameObject MainMenu => Resources.Load(ResourcesPath.MAIN_MENU) as GameObject;

        #endregion
    }
}
