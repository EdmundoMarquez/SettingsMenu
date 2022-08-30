using UnityEngine;
using System.IO;

namespace EdsDevExp.Save
{
    public static class PreferencesFileHandler
    {
        public static string directory = "/Data/Saved/";
        public static string fileName = "MyPreferences.txt";

        public static void Save(PreferencesObject save)
        {
            string fullPath = Application.dataPath + directory;

            if(!Directory.Exists(fullPath))
            {
                Debug.LogWarning("Preferences path doesn't exist. Creating directory...");
                Directory.CreateDirectory(fullPath);
            }

            string json = JsonUtility.ToJson(save);
            File.WriteAllText(fullPath + fileName, json);
        }

        public static PreferencesObject Load()
        {
            string fullPath = Application.dataPath + directory + fileName;

            PreferencesObject preferences = new PreferencesObject();
            if(File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                preferences = JsonUtility.FromJson<PreferencesObject>(json);
            }
            else
            {
                Debug.LogError("Preferences File Not Found");
            }

            return preferences;
        }
    }    
}


