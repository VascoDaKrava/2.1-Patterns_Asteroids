using System.IO;


namespace Asteroids
{
    public static class ResourcesPathAudio
    {

        #region Fields

        private const string FILE_MUSIC_MENU = "MenuMusic";

        private const string FILE_MUSIC_GAME = "GameMusic";

        private const string FILE_SFX_BUTTON_ENTER = "ButtonEnter";

        private const string FILE_SFX_BUTTON_CLICK = "ButtonPress";

        private const string FILE_AUDIO_MIXER = "AudioMixer";

        private const string FILE_SOUND_SETTINGS = "SoundSettingsDataSO";

        private const string FOLDER_AUDIO = "Audio";

        private const string FOLDER_SETTINGS = "Settings";


        private const string FILE_SFX_ENEMY_EXPLOSiON = "EnemyExplosion";

        private const string FILE_SFX_HIT_ASTEROID = "HitAsteroid";

        private const string FILE_SFX_HIT_ENEMY_SHIP = "HitEnemyShip";

        private const string FILE_SFX_MOVING_PLAYER_SHIP = "MovingPlaerShip";

        private const string FILE_SFX_MOVING_ENEMY_SHIP = "MovingEnemyShip";

        private const string FILE_SFX_SPAWN_ENEMY = "SpawnEnemy";

        private const string FILE_SFX_START_ROCKET = "StartRocket";

        #endregion


        #region Properties

        private static string FOLDER_MUSIC => Path.Combine(FOLDER_AUDIO, "Music");

        private static string FOLDER_SFX => Path.Combine(FOLDER_AUDIO, "Effects");

        public static string MUSIC_MENU => Path.Combine(FOLDER_MUSIC, FILE_MUSIC_MENU);
        
        public static string MUSIC_GAME => Path.Combine(FOLDER_MUSIC, FILE_MUSIC_GAME);
        
        public static string SFX_BUTTON_ENTER => Path.Combine(FOLDER_SFX, FILE_SFX_BUTTON_ENTER);
        
        public static string SFX_BUTTON_CLICK => Path.Combine(FOLDER_SFX, FILE_SFX_BUTTON_CLICK);
        
        public static string AUDIO_MIXER => Path.Combine(FOLDER_AUDIO, FILE_AUDIO_MIXER);

        public static string SOUND_SETTINGS => Path.Combine(FOLDER_SETTINGS, FILE_SOUND_SETTINGS);


        public static string SFX_ENEMY_EXPLOSION => Path.Combine(FOLDER_SFX, FILE_SFX_ENEMY_EXPLOSiON);

        public static string SFX_HIT_ASTEROID => Path.Combine(FOLDER_SFX, FILE_SFX_HIT_ASTEROID);

        public static string SFX_HIT_ENEMY_SHIP => Path.Combine(FOLDER_SFX, FILE_SFX_HIT_ENEMY_SHIP);

        public static string SFX_MOVING_PLAYER_SHIP => Path.Combine(FOLDER_SFX, FILE_SFX_MOVING_PLAYER_SHIP);

        public static string SFX_MOVING_ENEMY_SHIP => Path.Combine(FOLDER_SFX, FILE_SFX_MOVING_ENEMY_SHIP);

        public static string SFX_SPAWN_ENEMY => Path.Combine(FOLDER_SFX, FILE_SFX_SPAWN_ENEMY);

        public static string SFX_START_ROCKET => Path.Combine(FOLDER_SFX, FILE_SFX_START_ROCKET);

        #endregion

    }
}
