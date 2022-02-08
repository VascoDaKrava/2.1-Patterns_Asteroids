using UnityEngine;


namespace Asteroids
{
    public sealed class RootStarter
    {

        #region Fields

        private CollisionDetectorEvent _collisionDetectorEvent;
        private PauseMenuHandlers _pauseMenu;
        private ResourceManager _resourceManager;
        private SettingsData _settingsData;
        private SoundSystemPlayController _soundSystemPlayController;
        private SoundSystemVolumeController _soundSystemVolumeController;
        private TakeDamageEvent _takeDamageEvent;
        private UpdatableControllersFactory _controllersFactory;

        #endregion


        #region Properties

        public SoundSystemVolumeController SoundSystemVolumeController => _soundSystemVolumeController;

        #endregion


        #region ClassLifeCycles

        public RootStarter(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent)
        {
            _collisionDetectorEvent = new CollisionDetectorEvent();
            _resourceManager = new ResourceManager();
            _settingsData = DataSaveLoadRepo.LoadSettings();
            _takeDamageEvent = new TakeDamageEvent();

            _soundSystemPlayController = new SoundSystemPlayController();
            _soundSystemVolumeController = new SoundSystemVolumeController(_settingsData, _resourceManager.AudioMixer);
            new GraphicsQualityController(_settingsData);
            _soundSystemPlayController.PlaybackMusic(_soundSystemPlayController.AudioClips.Game);

            _pauseMenu = new PauseMenuHandlers(
                createUpdatableObjectEvent,
                destroyUpdatableObjectEvent,
                GameObject.Instantiate(_resourceManager.PauseMenu),
                _resourceManager.AudioMixer,
                _soundSystemPlayController);

            _controllersFactory = new UpdatableControllersFactory(
                createUpdatableObjectEvent,
                destroyUpdatableObjectEvent,
                _resourceManager,
                _collisionDetectorEvent,
                _takeDamageEvent,
                _soundSystemPlayController);

            _controllersFactory.CreateShipController(GameObject.FindGameObjectWithTag(TagsAndLayers.PLAYER_TAG).GetComponent<Rigidbody>());
            _controllersFactory.CreateFireController(GameObject.FindGameObjectWithTag(TagsAndLayers.BULLET_START_POSITION_TAG).transform);
            _controllersFactory.CreateEnemySpawner();

            _controllersFactory.CreateCheatUsage(_pauseMenu, GameObject.FindGameObjectWithTag(TagsAndLayers.PLAYER_TAG).transform);

            new ExplosionController(_collisionDetectorEvent, _resourceManager);

            new GameLoseController(_collisionDetectorEvent, _resourceManager, _soundSystemPlayController);
        }

        #endregion

    }
}
