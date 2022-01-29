using UnityEngine;


namespace Asteroids
{
    public sealed class SoundSystemPlayController
    {

        #region Fields

        private AudioSource _audioSourceMenu;
        private AudioSource _audioSourceSFX;
        private AudioSource _audioSourceMusic;

        #endregion


        #region ClassLifeCicles

        public SoundSystemPlayController()
        {
            _audioSourceMenu = GameObject.FindGameObjectWithTag(TagsAndLayers.MENU_AUDIOSOURCE_TAG).GetComponent<AudioSource>();
            _audioSourceSFX = GameObject.FindGameObjectWithTag(TagsAndLayers.SFX_AUDIOSOURCE_TAG).GetComponent<AudioSource>();
            _audioSourceMusic = GameObject.FindGameObjectWithTag(TagsAndLayers.MUSIC_AUDIOSOURCE_TAG).GetComponent<AudioSource>();

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

        public void PlaybackSFX(AudioClip audioClip)
        {
            _audioSourceSFX.PlayOneShot(audioClip);
        }

        public void PlaybackMenu(AudioClip audioClip)
        {
            _audioSourceMenu.PlayOneShot(audioClip);
        }

        #endregion

    }
}
