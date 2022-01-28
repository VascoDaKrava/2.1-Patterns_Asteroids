using UnityEngine;


namespace Asteroids
{
    public sealed class EnemyFactory
    {

        #region Methods

        public EnemyView CreateSmallAsteroid(ResourceManager resourceManager, Transform spawnPosition)
        {
            var asteroidSmall = GameObject.Instantiate(resourceManager.Asteroid, spawnPosition.position,
                spawnPosition.rotation).GetComponent<EnemyView>();

            return asteroidSmall;
        }

        public EnemyView CreateLargeAsteroid(ResourceManager resourceManager, Transform spawnPosition)
        {
            var asteroidLarge = GameObject.Instantiate(resourceManager.LargeAsteroid, spawnPosition.position,
                spawnPosition.rotation).GetComponent<EnemyView>();

            return asteroidLarge;
        }

        public EnemyView CreateEnemyShip(ResourceManager resourseManager, Transform spawnPosition)
        {
            var enemyShip = GameObject.Instantiate(resourseManager.EnemyShip, spawnPosition.position,
                spawnPosition.rotation).GetComponent<EnemyView>();

            return enemyShip;
        }

        #endregion

    }
}
