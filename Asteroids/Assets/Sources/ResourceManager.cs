using UnityEngine;


namespace Asteroids
{
    public sealed class ResourceManager
    {

        #region Properties

        public GameObject MissileAIM9 { get; private set; }

        public GameObject Asteroid { get; private set; }

        public GameObject LargeAsteroid { get; private set; }

        public GameObject EnemyShip { get; private set; }
        

        #endregion


        #region ClassLifeCycles

        public ResourceManager()
        {
            MissileAIM9 = Resources.Load<GameObject>(ResourcesPath.MISSILE_AIM9);
            Asteroid = Resources.Load<GameObject>(ResourcesPath.ASTEROID);
            LargeAsteroid = Resources.Load<GameObject>(ResourcesPath.LARGE_ASTEROID);
            EnemyShip = Resources.Load<GameObject>(ResourcesPath.ENEMY_SHIP);
        }

        #endregion

    }
}
