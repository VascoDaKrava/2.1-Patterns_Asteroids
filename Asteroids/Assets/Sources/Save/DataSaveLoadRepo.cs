using System.IO;
using System.Xml.Serialization;


namespace Asteroids
{
    public static class DataSaveLoadRepo
    {
        #region Methods

        public static void SaveSoundSettings(SoundSettingsData data)
        {
            XmlSerializer serializer = new XmlSerializer(data.GetType());

            if (!Directory.Exists(SaveLoadPath.FOLDER_SAVE))
                Directory.CreateDirectory(SaveLoadPath.FOLDER_SAVE);

            FileStream fs = new FileStream(
                SaveLoadPath.SETTINGS,
                FileMode.Create);

            serializer.Serialize(fs, data);

            fs.Close();
        }

        public static SoundSettingsData LoadSoundSettings()
        {
            SoundSettingsData data = new SoundSettingsData();

            if (File.Exists(SaveLoadPath.SETTINGS))
            {
                XmlSerializer serializer = new XmlSerializer(data.GetType());

                FileStream fs = new FileStream(
                    SaveLoadPath.SETTINGS,
                    FileMode.Open);

                data = (SoundSettingsData)serializer.Deserialize(fs);

                fs.Close();
            }

            return data;
        }

        #endregion

    }
}
