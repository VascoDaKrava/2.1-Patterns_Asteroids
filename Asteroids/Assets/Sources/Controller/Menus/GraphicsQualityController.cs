using UnityEngine;


namespace Asteroids
{
    /// <summary>
    /// Coresponding game graphics quality values with data from SettingsData
    /// </summary>
    public sealed class GraphicsQualityController
    {

        #region Fields

        private SettingsData _settingsData;

        #endregion


        #region Properties

        public int GraphicsQualityLevel
        {
            get
            {
                return QualitySettings.GetQualityLevel();
            }
            set
            {
                QualitySettings.SetQualityLevel(value);
            }
        }

        #endregion


        #region ClassLifeCycles

        public GraphicsQualityController(SettingsData settingsData)
        {
            _settingsData = settingsData;
            QualitySettings.SetQualityLevel(_settingsData.GraphicsQuality);
        }

        #endregion


        #region Methods

        public void SaveGraphicsSettings()
        {
            _settingsData.GraphicsQuality = QualitySettings.GetQualityLevel();
        }

        #endregion

    }
}
