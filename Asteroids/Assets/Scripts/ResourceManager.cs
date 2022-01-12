using UnityEngine;


namespace Asteroids
{

    public sealed class ResourceManager
    {

        #region Properties

        public Object MissileAIM9
        {
            get
            {
                return Resources.Load(ResourcesPath.MISSILE_AIM9);
            }
        }

        public Object Asteroid
        {
            get
            {
                return Resources.Load(ResourcesPath.ASTEROID);
            }
        }

        #endregion

    }
}
