﻿using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidModel : IDisposable
    {

        #region Fields

        private int _strengthAsteroid = 20;
        private float _speedAsteroid = 3.0f;
        private Vector3 _direction;
        private int _damageAsteroid = 10;

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
                _strengthAsteroid -= value;
            }
        }

        public float Speed { get => _speedAsteroid; }

        public int Damage { get => _damageAsteroid; }

        /// <summary>
        /// Direction moving of Asteroid
        /// </summary>
        public Vector3 Direction { get => _direction; }

        #endregion


        #region IDisposable

        public void Dispose()
        {  
        }

        #endregion

    }
}
