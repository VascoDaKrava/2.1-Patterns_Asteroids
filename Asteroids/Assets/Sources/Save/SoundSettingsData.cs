using System;


namespace Asteroids
{
    [Serializable]
    public sealed class SoundSettingsData
    {

        #region Fields

        public float VolumeMaster = 0.0f;

        public float VolumeMenu = -20.0f;

        public float VolumeMusic = -20.0f;

        public float VolumeSFX = -20.0f;

        #endregion

    }
}
