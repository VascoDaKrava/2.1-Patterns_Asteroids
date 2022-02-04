using UnityEngine;
using UnityEngine.Audio;


namespace Asteroids
{
    /// <summary>
    /// Coresponding AudioMixer values with data from SettingsData
    /// </summary>
    public sealed class SoundSystemVolumeController
    {

        #region Fields

        private AudioMixer _audioMixer;
        private SettingsData _settingsData;

        #endregion


        #region Properties

        public float VolumeMaster
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerParams.MASTER, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerParams.MASTER, value);
            }
        }

        public float VolumeMenu
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerParams.MENU, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerParams.MENU, value);
            }
        }

        public float VolumeMusic
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerParams.MUSIC, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerParams.MUSIC, value);
            }
        }

        public float VolumeSFX
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerParams.SFX, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerParams.SFX, value);
            }
        }

        #endregion


        #region ClassLifeCycles

        public SoundSystemVolumeController(SettingsData settingsData, AudioMixer audioMixer)
        {
            _settingsData = settingsData;
            _audioMixer = audioMixer;
            ApplySettings();
        }

        #endregion


        #region Methods

        public void ApplySettings()
        {
            VolumeMaster = _settingsData.VolumeMaster;
            VolumeMenu = _settingsData.VolumeMenu;
            VolumeMusic = _settingsData.VolumeMusic;
            VolumeSFX = _settingsData.VolumeSFX;
        }

        public void SaveSoundSettings()
        {
            _settingsData.VolumeMaster = VolumeMaster;
            _settingsData.VolumeMenu = VolumeMenu;
            _settingsData.VolumeMusic = VolumeMusic;
            _settingsData.VolumeSFX = VolumeSFX;
        }

        #endregion

    }
}
