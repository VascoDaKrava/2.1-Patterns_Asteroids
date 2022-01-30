using UnityEngine;


namespace Asteroids
{
    public sealed class ResourceManagerAudioClips
    {

        #region Properties

        public AudioClip AudioClipMenu { get; private set; }
        
        public AudioClip AudioClipGame { get; private set; }
        
        public AudioClip AudioClipButtonEnter { get; private set; }
        
        public AudioClip AudioClipButtonClick { get; private set; }

        #endregion


        #region ClassLifeCycles

        public ResourceManagerAudioClips()
        {
            AudioClipMenu = Resources.Load<AudioClip>(ResourcesPathAudio.MUSIC_MENU);
            AudioClipGame = Resources.Load<AudioClip>(ResourcesPathAudio.MUSIC_GAME);
            AudioClipButtonEnter = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_BUTTON_ENTER);
            AudioClipButtonClick = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_BUTTON_CLICK);
        }

        #endregion

    }
}
