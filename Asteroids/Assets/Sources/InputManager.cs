﻿using UnityEngine;


namespace Asteroids
{
    public sealed class InputManager
    {

        #region Fields

        private Vector3 _direction;

        #endregion


        #region Properties

        public bool isPrimaryFire => Input.GetButton(InputKeysAndAxis.KEY_PRIMARY_FIRE);

        public bool isSecondaryFire => Input.GetButtonDown(InputKeysAndAxis.KEY_AUTO_FIRE);

        public bool isPause => Input.GetButtonDown(InputKeysAndAxis.KEY_PAUSE);

        #endregion


        #region Methods

        /// <summary>
        /// Return normalized Vector 3 of direction if pressed move-keys
        /// </summary>
        /// <returns></returns>
        public Vector3 GetDirection()
        {
            _direction.x = Input.GetAxis(InputKeysAndAxis.AXIS_HORIZONTAL);
            _direction.y = 0.0f;
            _direction.z = Input.GetAxis(InputKeysAndAxis.AXIS_VERTICAL);

            return _direction.normalized;
        }

        #endregion

    }
}
