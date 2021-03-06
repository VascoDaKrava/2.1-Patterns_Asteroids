using UnityEngine;


namespace Asteroids
{
    public sealed class SoundSystemPlayController
    {

        #region Fields

        private AudioSource _audioSourceMenu;
        private AudioSource _audioSourceSFX;
        private AudioSource _audioSourceMusic;
        private ResourceManagerAudioClips _audioClips;

        #endregion


        #region Properties

        public ResourceManagerAudioClips AudioClips => _audioClips;

        #endregion


        #region ClassLifeCicles

        public SoundSystemPlayController()
        {
            _audioSourceMenu = GameObject.FindGameObjectWithTag(TagsAndLayers.MENU_AUDIOSOURCE_TAG).GetComponent<AudioSource>();
            _audioSourceSFX = GameObject.FindGameObjectWithTag(TagsAndLayers.SFX_AUDIOSOURCE_TAG).GetComponent<AudioSource>();
            _audioSourceMusic = GameObject.FindGameObjectWithTag(TagsAndLayers.MUSIC_AUDIOSOURCE_TAG).GetComponent<AudioSource>();

            _audioClips = new ResourceManagerAudioClips();

            _audioSourceMusic.loop = true;
        }

        #endregion


        #region Methods

        public void PlaybackMusic(bool isPlay)
        {
            if (isPlay)
            {
                _audioSourceMusic.Play();
            }
            else
            {
                _audioSourceMusic.Stop();
            }
        }

        public void PlaybackMusic(AudioClip audioClip)
        {
            _audioSourceMusic.clip = audioClip;
            PlaybackMusic(true);
        }

        public bool PlaybackSFX()
        {
            return _audioSourceSFX.isPlaying;
        }

        public void PlaybackSFX(AudioClip audioClip)
        {
            _audioSourceSFX.PlayOneShot(audioClip);
        }

        public void PlaybackSFX(AudioClip audioClip, bool isLoop)
        {
            _audioSourceSFX.clip = audioClip;
            _audioSourceSFX.loop = isLoop;

            if (isLoop)
            {
                _audioSourceSFX.Play();
            }
            else
            {
                _audioSourceSFX.Stop();
            }
        }

        public void PlaybackMenu(AudioClip audioClip)
        {
            _audioSourceMenu.PlayOneShot(audioClip);
        }

        #endregion

    }
}
