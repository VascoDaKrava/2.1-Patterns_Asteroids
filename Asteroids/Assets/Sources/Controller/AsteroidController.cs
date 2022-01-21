﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Asteroids
{
    public sealed class AsteroidController : UpdatableObject, IDisposable
    {

        #region Fields

        private AsteroidModel _asteroidModel;
        private AsteroidView _asteroidView;
        private Rigidbody _asteroidRigidbody;

        private CollisionDetectorEvent _collisionDetectorEvent;
        private TakeDamageEvent _takeDamageEvent;

        private float _minSpawnPositionX = -50.0f;
        private float _maxSpawnPositionX = 50.0f;
        private float _minDirectionX = -0.7f;
        private float _maxDirectionX = 0.7f;
        private float _minDirectionZ = 0.0f;
        private float _maxDirectionZ = -1.0f;

        #endregion


        #region ClassLifeCycles

        public AsteroidController(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            ResourceManager resourceManager,
            Transform spawnPosition,
            CollisionDetectorEvent collisionDetectorEvent,
            TakeDamageEvent takeDamageEvent) :
            base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _collisionDetectorEvent = collisionDetectorEvent;
            _takeDamageEvent = takeDamageEvent;

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
            _asteroidView.CollisionDetectorEvent = _collisionDetectorEvent;

            _collisionDetectorEvent.CollisionDetector += CollisionEventHandler;
            _takeDamageEvent.TakeDamage += TakeDamageEventHandler;
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
        public void ChangeStrength(int value)
        {
            _asteroidModel.Strength -= value;
            if (_asteroidModel.Strength <= 0)
            {
                _asteroidView.DestroyAsteroid();
                Dispose();
            }
        }

        private void CollisionEventHandler(Transform caller, Transform called)
        {
            if (caller.TryGetComponent(out AsteroidView callerView))
            {
                if (callerView == _asteroidView)
                {
                    _takeDamageEvent.Invoke(called, _asteroidModel.Damage);
                    //Dispose();
                }
            }
        }

        private void TakeDamageEventHandler(Transform damageReciever, int damage)
        {
            if (damageReciever.TryGetComponent(out AsteroidView damageRecieverView))
            {
                if (damageRecieverView == _asteroidView)
                {
                    ChangeStrength(damage);
                }
            }
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _asteroidView.DestroyAsteroid();
            
            _collisionDetectorEvent.CollisionDetector -= CollisionEventHandler;
            _takeDamageEvent.TakeDamage -= TakeDamageEventHandler;

            RemoveFromUpdate();
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
