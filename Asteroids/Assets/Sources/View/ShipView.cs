using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


namespace Asteroids
{
    public sealed class ShipView : MonoBehaviour
    {

        private float _switchSceneTime = 5.0f;

        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(TagsAndLayers.FLYING_AREA_TAG))
            {
                StartCoroutine(Wait(_switchSceneTime));
            }    
        }

        #endregion


        #region Methods

        /// <summary>
        /// Destroy ship
        /// </summary>
        /// <param name="deathTime"></param>
        public void DestroyShip()
        {
            Destroy(gameObject);
        }

        private IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(1);
        }

        #endregion

    }
}

