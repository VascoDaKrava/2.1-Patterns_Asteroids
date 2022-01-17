using UnityEngine;


namespace Asteroids
{
    public sealed class ResourceManager
    {

        #region Properties

        public GameObject MissileAIM9
        {
            get
            {
                return Resources.Load(ResourcesPath.MISSILE_AIM9) as GameObject;
            }
        }

        public GameObject Asteroid
        {
            get
            {
                return Resources.Load(ResourcesPath.ASTEROID) as GameObject;
            }
        }

        #endregion

    }
}
