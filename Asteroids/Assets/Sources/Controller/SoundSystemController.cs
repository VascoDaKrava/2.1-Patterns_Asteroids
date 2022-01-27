using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;


namespace Asteroids
{
    public sealed class SoundSystemController
    {

        #region Fields

        private AudioMixer _audioMixer;
        private AudioSource _audioSourceMain;

        #endregion


        #region Properties

        private float VolumeMaster
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

        private float VolumeMenu
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

        private float VolumeMusic
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

        private float VolumeSFX
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


        #region ClassLifeCicles

        public SoundSystemController(ResourceManagerAudioClips resourceManagerAudioClips)
        {
            _audioMixer = resourceManagerAudioClips.AudioMixerResource;
            _audioSourceMain = GameObject.FindGameObjectWithTag(TagsAndLayers.MAIN_CAMERA_TAG).GetComponent<AudioSource>();

            //_audioMixer.outputAudioMixerGroup.name = AudioMixerGroups.MASTER;
            _audioSourceMain.outputAudioMixerGroup = _audioMixer.outputAudioMixerGroup;
            //_audioSourceMain.outputAudioMixerGroup.name = AudioMixerGroups.MUSIC;
            _audioSourceMain.clip = resourceManagerAudioClips.AudioClipGame;
            _audioSourceMain.Play();
        }

        #endregion

    }
}
