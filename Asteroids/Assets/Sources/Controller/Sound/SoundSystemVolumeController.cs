using UnityEngine;
using UnityEngine.Audio;


namespace Asteroids
{
    public sealed class SoundSystemVolumeController
    {

        #region Fields

        private AudioMixer _audioMixer;
        private ResourceManagerSettings _settings;

        #endregion


        #region Properties

        public float VolumeMaster
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerGroups.MASTER, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerGroups.MASTER, value);
            }
        }

        public float VolumeMenu
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerGroups.MENU, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerGroups.MENU, value);
            }
        }

        public float VolumeMusic
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerGroups.MUSIC, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerGroups.MUSIC, value);
            }
        }

        public float VolumeSFX
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerGroups.SFX, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerGroups.SFX, value);
            }
        }

        #endregion


        #region ClassLifeCycles

        public SoundSystemVolumeController()
        {
            _audioMixer = Resources.Load<AudioMixer>(ResourcesPathAudio.AUDIO_MIXER);
            _settings = new ResourceManagerSettings();
        }

        #endregion


        #region Methods

        public void ApplySettings()
        {
            VolumeMaster = _settings.SoundSettings.VolumeMaster;
            VolumeMenu = _settings.SoundSettings.VolumeMenu;
            VolumeMusic = _settings.SoundSettings.VolumeMusic;
            VolumeSFX = _settings.SoundSettings.VolumeSFX;
        }

        #endregion

    }
}
