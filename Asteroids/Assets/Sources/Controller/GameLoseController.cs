using UnityEngine;
using UnityEngine.SceneManagement;


namespace Asteroids
{
    public sealed class GameLoseController
    {

        #region Fields

        private CollisionDetectorEvent _collisionDetectorEvent;
        private SoundSystemPlayController _soundPlay;
        private ResourceManager _resource;
        private ResourceManagerAudioClips _audioClips;

        #endregion


        #region ClassLifeCycles

        public GameLoseController(
            CollisionDetectorEvent collisionDetectorEvent,
            ResourceManager resourceManager,
            SoundSystemPlayController soundSystemPlayController,
            ResourceManagerAudioClips resourceManagerAudioClips)
        {
            _soundPlay = soundSystemPlayController;
            _resource = resourceManager;
            _audioClips = resourceManagerAudioClips;
            _collisionDetectorEvent = collisionDetectorEvent;
            _collisionDetectorEvent.CollisionDetector += CollisionHandeler;
        }

        ~GameLoseController()
        {
            _collisionDetectorEvent.CollisionDetector -= CollisionHandeler;
        }

        #endregion


        #region Methods

        private void CollisionHandeler(Transform transformA, Transform transformB)
        {
            if (transformB.GetComponent<ShipView>() && transformA.gameObject.layer == TagsAndLayers.ENEMY_LAYER ||
                transformA.GetComponent<ShipView>() && transformB.gameObject.layer == TagsAndLayers.ENEMY_LAYER)
            {
                DoGameLose();
            }
        }

        private void DoGameLose()
        {
            Time.timeScale = 0.0f;
            _resource.AudioMixer.SetFloat(AudioMixerParams.LOWPASS, AudioMixerParams.LOWPASS_LOW);
            _soundPlay.PlaybackSFX(_audioClips.GameLose);
            GameObject.Instantiate(_resource.GameLose).GetComponent<LoadSceneAfterTime>().StartLoadSceneAfterTime(_audioClips.GameLose.length, Scenes.MAIN_MENU);
        }

        #endregion

    }
}
