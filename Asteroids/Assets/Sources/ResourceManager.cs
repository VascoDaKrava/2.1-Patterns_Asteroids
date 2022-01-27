using UnityEngine;
using UnityEngine.Audio;


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
            MissileAIM9 = Resources.Load(ResourcesPath.MISSILE_AIM9) as GameObject;
            Asteroid = Resources.Load(ResourcesPath.ASTEROID) as GameObject;
            LargeAsteroid = Resources.Load(ResourcesPath.LARGE_ASTEROID) as GameObject;
            EnemyShip = Resources.Load(ResourcesPath.ENEMY_SHIP) as GameObject;
        }

        #endregion

    }
}
