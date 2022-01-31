using UnityEngine;
using UnityEngine.Audio;


namespace Asteroids
{
    public sealed class ResourceManagerAudioClips
    {

        #region Properties

        public AudioMixer AudioMixerResource { get; private set; }

        public AudioClip AudioClipMenu { get; private set; }
        
        public AudioClip AudioClipGame { get; private set; }
        
        public AudioClip AudioClipButtonEnter { get; private set; }
        
        public AudioClip AudioClipButtonClick { get; private set; }

        public AudioClip AudioClipEnemyExplosion { get; private set; }

        public AudioClip AudioClipHitAsteroid { get; private set; }

        public AudioClip AudioClipHitEnemyShip { get; private set; }

        public AudioClip AudioClipMovingEnemyShip { get; private set; }

        public AudioClip AudioClipMovingPlayerShip { get; private set; }

        public AudioClip AudioClipSpawnEnemy { get; private set; }

        public AudioClip AudioClipStartRocket { get; private set; }

        #endregion


        #region ClassLifeCycles

        public ResourceManagerAudioClips()
        {
            AudioMixerResource = Resources.Load<AudioMixer>(ResourcesPathAudio.AUDIO_MIXER);

            AudioClipMenu = Resources.Load<AudioClip>(ResourcesPathAudio.MUSIC_MENU);
            AudioClipGame = Resources.Load<AudioClip>(ResourcesPathAudio.MUSIC_GAME);
            AudioClipButtonEnter = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_BUTTON_ENTER);
            AudioClipButtonClick = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_BUTTON_CLICK);

            AudioClipEnemyExplosion = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_ENEMY_EXPLOSION);
            AudioClipHitAsteroid = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_HIT_ASTEROID);
            AudioClipHitEnemyShip = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_HIT_ENEMY_SHIP);
            AudioClipMovingEnemyShip = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_MOVING_ENEMY_SHIP);
            AudioClipMovingPlayerShip = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_MOVING_PLAYER_SHIP);
            AudioClipSpawnEnemy = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_SPAWN_ENEMY);
            AudioClipStartRocket = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_START_ROCKET);

        }

        #endregion

    }
}
