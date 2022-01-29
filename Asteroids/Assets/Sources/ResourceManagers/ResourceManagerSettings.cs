using UnityEngine;


namespace Asteroids
{
    public sealed class ResourceManagerSettings
    {

        #region Properties

        public SoundSettingsData SoundSettings { get; private set; }

        #endregion


        #region ClassLifeCycles

        public ResourceManagerSettings()
        {
            SoundSettings = Resources.Load<SoundSettingsData>(ResourcesPathAudio.SOUND_SETTINGS);
        }

        #endregion

    }
}
