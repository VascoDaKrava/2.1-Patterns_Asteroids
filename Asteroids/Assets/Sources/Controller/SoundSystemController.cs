using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;


namespace Asteroids
{
    public sealed class SoundSystemController
    {

        #region Fields

        private AudioMixer _audioMixer;

        #endregion


        #region ClassLifeCicles

        public SoundSystemController()
        {

            _audioMixer = new ResourceManager().AudioMixerResource;
        }

        #endregion

    }
}
