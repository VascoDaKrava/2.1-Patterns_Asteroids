using UnityEngine;
using UnityEngine.Audio;


namespace Asteroids
{
    public sealed class ResourceManager
    {

        #region Fields

        private AudioMixer _audioMixer;

        private GameObject _missile;
        private GameObject _asteroid;
        private GameObject _largeAsteroid;
        private GameObject _enemyShip;
        private GameObject _mainMenu;
        private GameObject _pauseMenu;

        #endregion


        #region Properties

        public AudioMixer AudioMixer => _audioMixer;

        public GameObject MissileAIM9 => _missile;

        public GameObject Asteroid => _asteroid;

        public GameObject LargeAsteroid => _largeAsteroid;

        public GameObject EnemyShip => _enemyShip;

        public GameObject MainMenu => _mainMenu;

        public GameObject PauseMenu => _pauseMenu;

        #endregion


        #region ClassLifeCycles

        public ResourceManager()
        {
            _audioMixer = Resources.Load<AudioMixer>(ResourcesPathAudio.AUDIO_MIXER);
            
            _missile = Resources.Load<GameObject>(ResourcesPath.MISSILE_AIM9);
            _asteroid = Resources.Load<GameObject>(ResourcesPath.ASTEROID);
            _largeAsteroid = Resources.Load<GameObject>(ResourcesPath.LARGE_ASTEROID);
            _enemyShip = Resources.Load<GameObject>(ResourcesPath.ENEMY_SHIP);
            _mainMenu = Resources.Load<GameObject>(ResourcesPath.MAIN_MENU);
            _pauseMenu = Resources.Load<GameObject>(ResourcesPath.PAUSE_MENU);
        }

        #endregion

    }
}
