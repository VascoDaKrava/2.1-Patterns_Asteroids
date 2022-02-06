using UnityEngine;


namespace Asteroids
{
    public sealed class ResourceManagerAudioClips
    {

        #region Properties

        public AudioClip Menu { get; private set; }
        public AudioClip Game { get; private set; }
        public AudioClip GameLose { get; private set; }
        public AudioClip ButtonEnter { get; private set; }
        public AudioClip ButtonClick { get; private set; }

        #endregion


        #region ClassLifeCycles

        public ResourceManagerAudioClips()
        {
            Menu = Resources.Load<AudioClip>(ResourcesPathAudio.MUSIC_MENU);
            Game = Resources.Load<AudioClip>(ResourcesPathAudio.MUSIC_GAME);
            GameLose = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_GAME_OVER);
            ButtonEnter = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_BUTTON_ENTER);
            ButtonClick = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_BUTTON_CLICK);
        }

        #endregion

    }
}
