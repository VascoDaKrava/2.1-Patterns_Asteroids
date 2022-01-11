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
                resourceManager.Asteroid as GameObject,
                spawnPosition.position = new Vector3(Random.Range(-30, 30), 
                spawnPosition.position.y, Random.Range(spawnPosition.position.z, 100)),
                spawnPosition.rotation).GetComponent<AsteroidView>();

            _asteroidRigidbody = _asteroidView.gameObject.GetComponent<Rigidbody>();

            _asteroidView.Damage = _asteroidModel.Damage;
            _asteroidView.Strength = _asteroidModel.Strength;
        }

        #endregion


        #region Methods

        private void AsteroidFly()
        {
            _asteroidRigidbody.velocity = _asteroidRigidbody.gameObject.transform.forward * _asteroidModel.Speed;
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            RemoveFromUpdate();
            _asteroidModel.Dispose();
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
