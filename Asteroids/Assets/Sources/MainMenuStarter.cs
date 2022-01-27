using UnityEngine;


namespace Asteroids
{
    public sealed class MainMenuStarter : MonoBehaviour
    {

        #region Fields

        private ResourceManager _resources;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _resources = new ResourceManager();
            new MainMenuController(Instantiate(_resources.MainMenu).GetComponent<MainMenuElements>());
        }

        #endregion

    }
}
