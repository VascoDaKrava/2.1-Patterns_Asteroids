using UnityEngine;


namespace Asteroids
{
    public static class InputManager
    {

        #region Properties

        public static bool isPrimaryFire => Input.GetButton(InputKeysAndAxis.KEY_PRIMARY_FIRE);
        public static bool isSecondaryFire => Input.GetButtonDown(InputKeysAndAxis.KEY_AUTO_FIRE);
        public static bool isPause => Input.GetButtonDown(InputKeysAndAxis.KEY_PAUSE);
        public static bool isCheat => Input.GetButtonDown(InputKeysAndAxis.KEY_CHEAT);

        #endregion


        #region Methods

        /// <summary>
        /// Return normalized Vector 3 of direction if pressed move-keys
        /// </summary>
        /// <returns></returns>
        public static Vector3 GetDirection()
        {
            Vector3 direction = new Vector3();
            direction.x = Input.GetAxis(InputKeysAndAxis.AXIS_HORIZONTAL);
            direction.y = 0.0f;
            direction.z = Input.GetAxis(InputKeysAndAxis.AXIS_VERTICAL);

            return direction.normalized;
        }

        #endregion

    }
}
