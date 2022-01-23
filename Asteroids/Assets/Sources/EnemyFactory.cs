using UnityEngine;


namespace Asteroids
{
    /// <summary>
    /// Factory for creating enemy
    /// </summary>
    public sealed class EnemyFactory
    {

        #region Fields

        private float _minSpawnPositionX = -50.0f;
        private float _maxSpawnPositionX = 50.0f;

        #endregion


        #region Methods

        public EnemyView CreateSmallAsteroid(ResourceManager resourceManager, Transform spawnPosition)
        {
            var asteroidSmall = GameObject.Instantiate(resourceManager.Asteroid,
                spawnPosition.position = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX),
                spawnPosition.position.y, spawnPosition.position.z),
                spawnPosition.rotation).GetComponent<EnemyView>();

            return asteroidSmall;
        }

        public EnemyView CreateLargeAsteroid(ResourceManager resourceManager, Transform spawnPosition)
        {
            var asteroidLarge = GameObject.Instantiate(resourceManager.LargeAsteroid,
                spawnPosition.position = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX),
                spawnPosition.position.y, spawnPosition.position.z),
                spawnPosition.rotation).GetComponent<EnemyView>();

            return asteroidLarge;
        }

        public EnemyView CreateEnemyShip(ResourceManager resourseManager, Transform spawnPosition)
        {
            var enemyShip = GameObject.Instantiate(resourseManager.EnemyShip,
                spawnPosition.position = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX),
                spawnPosition.position.y, spawnPosition.position.z),
                spawnPosition.rotation).GetComponent<EnemyView>();

            return enemyShip;
        }

        #endregion
    }
}
