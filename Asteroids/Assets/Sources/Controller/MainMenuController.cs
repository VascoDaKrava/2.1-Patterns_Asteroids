using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Asteroids
{
    public sealed class MainMenuController
    {

        #region Fields

        private const string MAIN_SCENE = "MainScene";

        private MainMenuElements _menuElements;

        #endregion


        #region ClassLifeCycles

        public MainMenuController(MainMenuElements menuElements)
        {
            _menuElements = menuElements;

            SetMenuOptionsVisible(false);

            SubscribeOnClick();
        }

        ~MainMenuController()
        {
            UnsubscribeOnClick();
        }

        #endregion


        #region Methods

        private void SetMenuOptionsVisible(bool visible)
        {
            _menuElements.MenuOptions.gameObject.SetActive(visible);
        }

        private void SetMenuButtonsVisible(bool visible)
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
            _menuElements.ButtonBack.onClick.AddListener(ButtonBackOnClickHandler);

        }

        private void UnsubscribeOnClick()
        {
            _menuElements.ButtonStart.onClick.RemoveListener(ButtonStartOnClickHandler);
            _menuElements.ButtonOptions.onClick.RemoveListener(ButtonOptionsOnClickHandler);
            _menuElements.ButtonExit.onClick.RemoveListener(ButtonExitOnClickHandler);
            _menuElements.ButtonBack.onClick.RemoveListener(ButtonBackOnClickHandler);

        }

        private void ButtonStartOnClickHandler()
        {
            SceneManager.LoadScene(MAIN_SCENE);
        }

        private void ButtonOptionsOnClickHandler()
        {
            SetMenuButtonsVisible(false);
            SetMenuOptionsVisible(true);
        }

        private void ButtonExitOnClickHandler()
        {
            if (EditorApplication.isPlaying) 
                EditorApplication.isPlaying = false;
            
            Application.Quit();
        }

        private void ButtonBackOnClickHandler()
        {
            SetMenuOptionsVisible(false);
            SetMenuButtonsVisible(true);
        }

        #endregion


        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Enter : " + eventData.pointerEnter);
        }

    }
}
