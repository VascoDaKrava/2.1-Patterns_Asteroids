using UnityEngine;


namespace Asteroids
{
    public sealed class RootStarter
    {

        #region Fields

        private CollisionDetectorEvent _collisionDetectorEvent;
        private ResourceManager _resourceManager;
        private ResourceManagerAudioClips _resourceManagerAudioClips;
        private Rigidbody _shipRigidbody;
        private SettingsData _settingsData;
        private SoundSystemPlayController _soundSystemPlayController;
        private SoundSystemVolumeController _soundSystemVolumeController;
        private TakeDamageEvent _takeDamageEvent;
        private Transform _bulletStartTransform;
        private Transform _spawnPosition;
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
            _resourceManagerAudioClips = new ResourceManagerAudioClips();
            _settingsData = DataSaveLoadRepo.LoadSettings();
            _takeDamageEvent = new TakeDamageEvent();

            _soundSystemPlayController = new SoundSystemPlayController();
            _soundSystemVolumeController = new SoundSystemVolumeController(_settingsData, _resourceManager.AudioMixer);
            new GraphicsQualityController(_settingsData);
            _soundSystemPlayController.PlaybackMusic(_resourceManagerAudioClips.AudioClipGame);

            new PauseMenuHandlers(
                createUpdatableObjectEvent,
                destroyUpdatableObjectEvent,
                GameObject.Instantiate(_resourceManager.PauseMenu),
                _resourceManager.AudioMixer,
                _soundSystemPlayController,
                _resourceManagerAudioClips);

            _controllersFactory = new UpdatableControllersFactory(
                createUpdatableObjectEvent,
                destroyUpdatableObjectEvent,
                _resourceManager,
                _collisionDetectorEvent,
                _takeDamageEvent);

            _shipRigidbody = GameObject.FindGameObjectWithTag(TagsAndLayers.PLAYER_TAG).GetComponent<Rigidbody>();
            _bulletStartTransform = GameObject.FindGameObjectWithTag(TagsAndLayers.BULLET_START_POSITION_TAG).transform;
            _spawnPosition = GameObject.FindGameObjectWithTag(TagsAndLayers.SPAWN_POSITION_TAG).transform;

            _controllersFactory.CreateShipController(_shipRigidbody);
            _controllersFactory.CreateFireController(_bulletStartTransform, _controllersFactory);
            _controllersFactory.CreateEnemySpawner(_spawnPosition, _resourceManager, _controllersFactory);

            new ExplosionController(_collisionDetectorEvent, _resourceManager);
        }

        #endregion

    }
}
