using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Asteroids
{
    public sealed class AsteroidController: UpdatableObject, IDisposable
    {

        #region Fields

        private AsteroidModel _asteroidModel;
        private AsteroidView _asteroidView;
        private Rigidbody _asteroidRigidbody;

        private float _minSpawnPositionX = -50.0f;
        private float _maxSpawnPositionX = 50.0f;
        private float _minDirectionX = -0.7f;
        private float _maxDirectionX = 0.7f;
        private float _minDirectionZ = 0.0f;
        private float _maxDirectionZ = -1.0f;

        #endregion


        #region Properties

        /// <summary>
        /// Get value of asteroid damage
        /// </summary>
        public int AsteroidDamageValue
        {
            get => _asteroidModel.Damage;
        }

        #endregion


        #region ClassLifeCycles

        public AsteroidController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            ResourceManager resourceManager,
            Transform spawnPosition) :
            base (createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _asteroidModel = new AsteroidModel();

            _asteroidView = GameObject.Instantiate(
                resourceManager.Asteroid,
                spawnPosition.position = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX), 
                spawnPosition.position.y, spawnPosition.position.z),
                spawnPosition.rotation).GetComponent<AsteroidView>();

            _asteroidRigidbody = _asteroidView.gameObject.GetComponent<Rigidbody>();

            _asteroidModel.Direction = new Vector3(Random.Range(_minDirectionX, _maxDirectionX),
                0.0f, Random.Range(_minDirectionZ, _maxDirectionZ));

            _asteroidView.DestroyAsteroidTime(_asteroidModel.DeathTime);

            _asteroidView.Damage = _asteroidModel.Damage;      // is it ok?

            _asteroidView.onGetDamageEvent.OnGetDamage += ChangeStrength;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Moving asteroid in given direction
        /// </summary>
        private void AsteroidFly()
        {
            if (_asteroidRigidbody != null)
            {
                _asteroidRigidbody.velocity = _asteroidModel.Direction * _asteroidModel.Speed;
            }
            
        }

        /// <summary>
        /// Changing asteroid strength from missile damage
        /// </summary>
        /// <param name="value"></param>
        public void ChangeStrength (int value)
        {
            _asteroidModel.Strength -= value;
            if (_asteroidModel.Strength <= 0)
            {
                _asteroidView.DestroyAsteroid();
            }
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            RemoveFromUpdate();
            _asteroidView.onGetDamageEvent.OnGetDamage -= ChangeStrength;
        }

        #endregion


        #region IUpdatable

        public override void LetUpdate()
        {
            AsteroidFly();
        }

        #endregion

    }
}
