namespace Asteroids
{
    public sealed class ResourceManagerSettings
    {

        #region Properties

        public SoundSettingsData SoundSettings
        {
            get
            {
                return DataSaveLoadRepo.LoadSoundSettings();
            }
            set
            {
                DataSaveLoadRepo.SaveSoundSettings(value);
            }
        }

        #endregion


        #region ClassLifeCycles

        public ResourceManagerSettings()
        {
        }

        #endregion

    }
}
