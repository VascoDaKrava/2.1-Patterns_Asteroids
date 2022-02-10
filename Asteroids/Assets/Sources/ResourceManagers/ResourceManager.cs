using UnityEngine;
using UnityEngine.Audio;


namespace Asteroids
{
    public sealed class ResourceManager
    {

        #region Fields

        private AudioMixer _audioMixer;

        private GameObject _asteroid;
        private GameObject _enemyShip;
        private GameObject _explosion;
        private GameObject _gameLose;
        private GameObject _largeAsteroid;
        private GameObject _mainMenu;
        private GameObject _missile;
        private GameObject _pauseMenu;

        #endregion


        #region Properties

        public AudioMixer AudioMixer => _audioMixer;

        public GameObject Asteroid => _asteroid;

        public GameObject EnemyShip => _enemyShip;

        public GameObject Explosion => _explosion;

        public GameObject GameLose => _gameLose;

        public GameObject LargeAsteroid => _largeAsteroid;

        public GameObject MainMenu => _mainMenu;

        public GameObject MissileAIM9 => _missile;

        public GameObject PauseMenu => _pauseMenu;

        #endregion


        #region ClassLifeCycles

        public ResourceManager()
        {
            _audioMixer = Resources.Load<AudioMixer>(ResourcesPathAudio.AUDIO_MIXER);
            
            _asteroid = Resources.Load<GameObject>(ResourcesPath.ASTEROID);
            _enemyShip = Resources.Load<GameObject>(ResourcesPath.ENEMY_SHIP);
            _explosion = Resources.Load<GameObject>(ResourcesPath.EXPLOSION);
            _gameLose = Resources.Load<GameObject>(ResourcesPath.GAME_LOSE);
            _largeAsteroid = Resources.Load<GameObject>(ResourcesPath.LARGE_ASTEROID);
            _mainMenu = Resources.Load<GameObject>(ResourcesPath.MAIN_MENU);
            _missile = Resources.Load<GameObject>(ResourcesPath.MISSILE_AIM9);
            _pauseMenu = Resources.Load<GameObject>(ResourcesPath.PAUSE_MENU);
        }

        #endregion

    }
}
