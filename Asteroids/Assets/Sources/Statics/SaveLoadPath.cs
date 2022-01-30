using System.IO;
using UnityEngine;


namespace Asteroids
{
    public static class SaveLoadPath
    {

        #region Fields

        private const string FILE_SETTINGS_XML = "Settings.xml";

        public const string FOLDER_SAVE = "Save";

        #endregion


        #region Properties

        public static string SETTINGS => Path.Combine(Application.dataPath, FOLDER_SAVE, FILE_SETTINGS_XML);

        #endregion

    }
}
