using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidModel : IDisposable
    {

        #region Fields

        private int _strengthAsteroid = 20;
        private float _speedAsteroid = 10.0f;
        private Vector3 _direction;
        private int _damageAsteroid = 20;
        private float _deathTime = 15.0f;

        #endregion


        #region Properties

        /// <summary>
        /// Strength of Asteroid
        /// </summary>
        public int Strength
        {
            get => _strengthAsteroid;

            set
            {
                _strengthAsteroid = value;
            }
        }

        /// <summary>
        /// Direction moving of Asteroid
        /// </summary>
        public Vector3 Direction
        {
            get => _direction;

            set
            {
                _direction = value;
            }
        }

        /// <summary>
        /// Time for destroy asteroid
        /// </summary>
        public float DeathTime { get => _deathTime; }

        public float Speed { get => _speedAsteroid; }

        public int Damage { get => _damageAsteroid; }

        #endregion


        #region IDisposable

        public void Dispose()
        {  
        }

        #endregion


    }
}
