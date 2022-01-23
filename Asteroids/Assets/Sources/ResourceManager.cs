using UnityEngine;


namespace Asteroids
{
    public sealed class ResourceManager
    {

        #region Properties

        public GameObject MissileAIM9 => Resources.Load(ResourcesPath.MISSILE_AIM9) as GameObject;

        public GameObject Asteroid => Resources.Load(ResourcesPath.ASTEROID) as GameObject;

        public GameObject LargeAsteroid => Resources.Load(ResourcesPath.LARGE_ASTEROID) as GameObject;

        public GameObject EnemyShip => Resources.Load(ResourcesPath.ENEMY_SHIP) as GameObject;

        #endregion

    }
}
