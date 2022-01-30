namespace Asteroids
{
    public sealed class SoundSettingsData
    {

        #region Fields

        private float _volumeMaster = -20.0f;

        private float _volumeMenu = -20.0f;

        private float _volumeMusic = -20.0f;

        private float _volumeSFX = -20.0f;

        #endregion


        #region Properties

        public float VolumeMaster => _volumeMaster;
        public float VolumeMenu => _volumeMenu;
        public float VolumeMusic => _volumeMusic;
        public float VolumeSFX => _volumeSFX;

        #endregion

    }
}
