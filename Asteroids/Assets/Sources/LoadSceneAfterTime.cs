using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


namespace Asteroids
{
    public sealed class LoadSceneAfterTime : MonoBehaviour
    {

        #region Methods

        public void StartLoadSceneAfterTime(float time, string sceneName)
        {
            StartCoroutine(Wait(time, sceneName));
        }
        
        private IEnumerator Wait(float time, string sceneName)
        {
            yield return new WaitForSecondsRealtime(time);
            SceneManager.LoadScene(sceneName);
        }

        #endregion

    }
}
