using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu]
    public sealed class SoundSettingsDataSO : ScriptableObject
    {

        #region Fields

        [SerializeField]
        private float _volumeMaster = -20.0f;

        [SerializeField]
        private float _volumeMenu = -20.0f;

        [SerializeField]
        private float _volumeMusic = -20.0f;

        [SerializeField]
        private float _volumeSFX = -20.0f;

        #endregion


        #region Properties

        public float VolumeMaster => _volumeMaster;
        public float VolumeMenu => _volumeMenu;
        public float VolumeMusic => _volumeMusic;
        public float VolumeSFX => _volumeSFX;

        #endregion

    }
}
