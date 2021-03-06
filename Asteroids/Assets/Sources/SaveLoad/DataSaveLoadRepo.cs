using System.IO;
using System.Xml.Serialization;


namespace Asteroids
{
    public static class DataSaveLoadRepo
    {

        #region Methods

        public static void SaveSettings(SettingsData data)
        {
            XmlSerializer serializer = new XmlSerializer(data.GetType());

            if (!Directory.Exists(Path.GetDirectoryName(SaveLoadPath.PATH_TO_SETTINGS_FILE)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(SaveLoadPath.PATH_TO_SETTINGS_FILE));
            }

            FileStream fs = new FileStream(
                SaveLoadPath.PATH_TO_SETTINGS_FILE,
                FileMode.Create);

            serializer.Serialize(fs, data);

            fs.Close();
        }

        public static SettingsData LoadSettings()
        {
            SettingsData data = new SettingsData();

            if (File.Exists(SaveLoadPath.PATH_TO_SETTINGS_FILE))
            {
                XmlSerializer serializer = new XmlSerializer(data.GetType());

                FileStream fs = new FileStream(
                    SaveLoadPath.PATH_TO_SETTINGS_FILE,
                    FileMode.Open);

                data = (SettingsData)serializer.Deserialize(fs);

                fs.Close();
            }

            return data;
        }

        #endregion

    }
}
