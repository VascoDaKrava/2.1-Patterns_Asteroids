using UnityEngine;
using UnityEngine.Audio;


namespace Asteroids
{
    public sealed class SoundSystemVolumeController
    {

        #region Fields

        private AudioMixer _audioMixer;
        private SoundSettingsData _soundSettingsData;

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
            _soundSettingsData = DataSaveLoadRepo.LoadSoundSettings();
            ApplySettings();
        }

        #endregion


        #region Methods

        public void ApplySettings()
        {
            VolumeMaster = _soundSettingsData.VolumeMaster;
            VolumeMenu = _soundSettingsData.VolumeMenu;
            VolumeMusic = _soundSettingsData.VolumeMusic;
            VolumeSFX = _soundSettingsData.VolumeSFX;
        }

        public void SaveSettings()
        {
            _soundSettingsData.VolumeMaster = VolumeMaster;
            _soundSettingsData.VolumeMenu = VolumeMenu;
            _soundSettingsData.VolumeMusic = VolumeMusic;
            _soundSettingsData.VolumeSFX = VolumeSFX;

            DataSaveLoadRepo.SaveSoundSettings(_soundSettingsData);
        }

        #endregion

    }
}
