using UnityEngine;


namespace Asteroids
{
    public sealed class ShipView : MonoBehaviour
    {

        #region Methods

        public void DestroyShip()
        {
            Destroy(gameObject);
        }

        #endregion

    }
}

