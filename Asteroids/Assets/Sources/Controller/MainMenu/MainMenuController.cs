#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Asteroids
{
    public sealed class MainMenuController
    {

        #region Fields

        private MainMenuElements _menuElements;
        private MainMenuOptionsController _optionsController;

        #endregion


        #region ClassLifeCycles

        public MainMenuController(MainMenuElements menuElements, SoundSystemVolumeController volumeController)
        {
            _menuElements = menuElements;

            _optionsController = new MainMenuOptionsController(menuElements, this, volumeController);

            _optionsController.SetMenuOptionsVisible(false);

            SubscribeOnClick();
        }

        ~MainMenuController()
        {
            UnsubscribeOnClick();
        }

        #endregion


        #region Methods

        public void SetMenuButtonsVisible(bool visible)
        {
            _menuElements.ButtonStart.interactable = visible;
            _menuElements.ButtonOptions.interactable = visible;
            _menuElements.ButtonExit.interactable = visible;
        }

        private void SubscribeOnClick()
        {
            _menuElements.ButtonStart.onClick.AddListener(ButtonStartOnClickHandler);
            _menuElements.ButtonOptions.onClick.AddListener(ButtonOptionsOnClickHandler);
            _menuElements.ButtonExit.onClick.AddListener(ButtonExitOnClickHandler);
        }

        private void UnsubscribeOnClick()
        {
            _menuElements.ButtonStart.onClick.RemoveListener(ButtonStartOnClickHandler);
            _menuElements.ButtonOptions.onClick.RemoveListener(ButtonOptionsOnClickHandler);
            _menuElements.ButtonExit.onClick.RemoveListener(ButtonExitOnClickHandler);
        }

        private void ButtonStartOnClickHandler()
        {
            SceneManager.LoadScene(Scenes.FIRST_LEVEL);
        }

        private void ButtonOptionsOnClickHandler()
        {
            SetMenuButtonsVisible(false);
            _optionsController.SetMenuOptionsVisible(true);
        }

        private void ButtonExitOnClickHandler()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Enter : " + eventData.pointerEnter);
        }

        #endregion

    }
}
