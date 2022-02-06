namespace Asteroids
{
    /// <summary>
    /// Contain Tags
    /// </summary>
    public static class TagsAndLayers
    {

        #region Fields

        public const string PLAYER_TAG = "Player";
        public const string BULLET_START_POSITION_TAG = "BulletStartPosition";
        public const string FLYING_AREA_TAG = "FlyingArea";
        public const string MAIN_CAMERA_TAG = "MainCamera";
        public const string MUSIC_AUDIOSOURCE_TAG = "MusicSource";
        public const string SFX_AUDIOSOURCE_TAG = "SFXSource";
        public const string MENU_AUDIOSOURCE_TAG = "MenuSource";

        public const int ENEMY_LAYER = 1 << 6;

        #endregion

    }
}