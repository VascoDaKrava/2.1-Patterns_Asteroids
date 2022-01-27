using System.IO;
using UnityEngine;


namespace Asteroids
{
    public static class AudioPath
    {

        #region Fields

        public const string MUSIC_MENU = "MenuMusic.mp3";

        public const string MUSIC_GAME = "GameMusic.mp3";

        public const string SFX_BUTTON_ENTER = "ButtonEnter";

        public const string SFX_BUTTON_PRESS = "ButtonPress";

        #endregion


        #region Properties

        public static string FOLDER_AUDIO => Path.Combine(Application.dataPath, "Audio");

        public static string FOLDER_MUSIC => Path.Combine(Application.dataPath, "Audio", "Music");

        public static string FOLDER_SFX => Path.Combine(Application.dataPath, "Audio", "Effects");

        #endregion

    }
}
