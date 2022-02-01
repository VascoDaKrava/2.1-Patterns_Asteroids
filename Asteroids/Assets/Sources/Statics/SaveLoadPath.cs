using System.IO;
using UnityEngine;


namespace Asteroids
{
    public static class SaveLoadPath
    {

        #region Fields

        private const string FILE_SETTINGS_XML = "Settings.xml";

        private const string FOLDER_SAVE = "Save";

        #endregion


        #region Properties

        public static string PATH_TO_SETTINGS_FILE => Path.Combine(Application.dataPath, FOLDER_SAVE, FILE_SETTINGS_XML);

        #endregion

    }
}
