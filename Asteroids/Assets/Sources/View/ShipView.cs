using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


namespace Asteroids
{
    public sealed class ShipView : MonoBehaviour
    {

        #region Methods

        /// <summary>
        /// Destroy ship
        /// </summary>
        /// <param name="deathTime"></param>
        public void DestroyShip()
        {
            Destroy(gameObject);
        }

        #endregion
    }
}

