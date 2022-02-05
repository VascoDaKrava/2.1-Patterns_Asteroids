using UnityEngine;


namespace Asteroids
{
    /// <summary>
    /// Factory for creating enemy
    /// </summary>
    public sealed class EnemyViewFactory
    {

        #region Fields

        private ResourceManager _resourceManager;

        #endregion


        #region ClassLifeCycles

        public EnemyViewFactory(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        #endregion


        #region Methods

        public EnemyView CreateSmallAsteroid()
        {
            var asteroidSmall = GameObject.Instantiate(_resourceManager.Asteroid, Vector3.zero,
                Quaternion.identity).GetComponent<EnemyView>();

            return asteroidSmall;
        }

        public EnemyView CreateLargeAsteroid()
        {
            var asteroidLarge = GameObject.Instantiate(_resourceManager.LargeAsteroid, Vector3.zero,
                Quaternion.identity).GetComponent<EnemyView>();

            return asteroidLarge;
        }

        public EnemyView CreateEnemyShip()
        {
            var enemyShip = GameObject.Instantiate(_resourceManager.EnemyShip, Vector3.zero,
                Quaternion.identity).GetComponent<EnemyView>();

            return enemyShip;
        }

        #endregion

    }
}
