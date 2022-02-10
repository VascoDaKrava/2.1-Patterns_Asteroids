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

        public AudioClip EnemyDie { get; private set; }

        public AudioClip EnemySpawn { get; private set; }

        public AudioClip HitAsteroid { get; private set; }

        public AudioClip HitEnemyShip { get; private set; }

        public AudioClip MovingEnemyShip { get; private set; }

        public AudioClip MovingPlayerShip { get; private set; }

        public AudioClip StartMissile { get; private set; }

        #endregion


        #region ClassLifeCycles

        public ResourceManagerAudioClips()
        {
            Menu = Resources.Load<AudioClip>(ResourcesPathAudio.MUSIC_MENU);
            Game = Resources.Load<AudioClip>(ResourcesPathAudio.MUSIC_GAME);
            GameLose = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_GAME_OVER);
            ButtonEnter = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_BUTTON_ENTER);
            ButtonClick = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_BUTTON_CLICK);

            EnemyDie = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_ENEMY_EXPLOSION);
            EnemySpawn = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_SPAWN_ENEMY);
            HitAsteroid = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_HIT_ASTEROID);
            HitEnemyShip = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_HIT_ENEMY_SHIP);
            MovingEnemyShip = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_MOVING_ENEMY_SHIP);
            MovingPlayerShip = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_MOVING_PLAYER_SHIP);
            StartMissile = Resources.Load<AudioClip>(ResourcesPathAudio.SFX_START_MISSILE);
        }

        #endregion

    }
}
