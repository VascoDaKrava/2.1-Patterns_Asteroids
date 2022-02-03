using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Asteroids
{
    public sealed class TimerForChangeScene : MonoBehaviour
    {

        #region Fields

        private float _switchSceneTime = 7.0f;

        #endregion


        #region UnityMethods

        private void Start()
        {
            if (this.gameObject.activeSelf)
            {
                StartCoroutine(Wait(_switchSceneTime));
            }
        }

        #endregion


        #region Methods

        
        private IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(1);
        }

        #endregion
    }
}
