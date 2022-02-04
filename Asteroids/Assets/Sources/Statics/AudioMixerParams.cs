namespace Asteroids
{
    public static class AudioMixerParams
    {

        #region Fields

        public const string MASTER = "VolumeMaster";
        public const string MUSIC = "VolumeMusic";
        public const string MENU = "VolumeMenu";
        public const string SFX = "VolumeSFX";

        public const string LOWPASS = "LowpassFrequency";
        public const float LOWPASS_HIGH = 22000.0f;
        public const float LOWPASS_LOW = 750.0f;

        #endregion

    }
}
