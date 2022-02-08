using TMPro;
using UnityEngine;


namespace Asteroids
{
    public sealed class TextHider : MonoBehaviour
    {

        #region Fields

        private const float TIME_TO_HIDE = 5.0f; // Time in seconds

        private bool _isVisible = false;
        private float _elapsedTime;

        private TextMeshProUGUI _text;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (_text.alpha == 1.0f)
            {
                _isVisible = true;
                _elapsedTime = TIME_TO_HIDE;
            }
            if (_isVisible)
            {
                MakeUnvisible();
            }
        }

        #endregion


        #region Methods

        private void MakeUnvisible()
        {
            _text. alpha = 1.0f - Mathf.Lerp(0.1f, 0.9f, (TIME_TO_HIDE - _elapsedTime) / TIME_TO_HIDE);
            _elapsedTime -= Time.deltaTime;

            if (_elapsedTime <= 0.0f)
            {
                _isVisible = false;
                _text.alpha = 0.0f;
            }
        }

        #endregion

    }
}
