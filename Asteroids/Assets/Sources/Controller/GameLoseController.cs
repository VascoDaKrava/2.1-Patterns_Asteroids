using UnityEngine;


namespace Asteroids
{
    public sealed class GameLoseController
    {

        #region Fields

        private CollisionDetectorEvent _collisionDetectorEvent;
        private SoundSystemPlayController _audioPlay;
        private ResourceManager _resource;

        #endregion


        #region ClassLifeCycles

        public GameLoseController(
            CollisionDetectorEvent collisionDetectorEvent,
            ResourceManager resourceManager,
            SoundSystemPlayController soundSystemPlayController)
        {
            _audioPlay = soundSystemPlayController;
            _resource = resourceManager;
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
            _audioPlay.PlaybackSFX(_audioPlay.AudioClips.GameLose);
            GameObject.Instantiate(_resource.GameLose).GetComponent<LoadSceneAfterTime>().StartLoadSceneAfterTime(_audioPlay.AudioClips.GameLose.length, Scenes.MAIN_MENU);
        }

        #endregion

    }
}
