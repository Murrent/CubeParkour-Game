using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelFilesManager : MonoBehaviour
{
    public List<LevelDataClass> levels;
    public void VerifyAllFiles()
    {
        for (int i = 0; i < levels.Count; i++)
            VerifyFiles(levels[i]);
    }

    public void VerifyFiles(LevelDataClass levelData)
    {
        //Checking if the directory exists
        if (Directory.Exists(Application.persistentDataPath + "/Score"))
        {
            //Checking if the file exists
            if (System.IO.File.Exists(Application.persistentDataPath + "/Score/" + levelData.levelName + ".json"))
            {
                return;
            }
            else //Creating a file and writing levelData into it
            {
                string json = JsonUtility.ToJson(levelData);
                File.WriteAllText(Application.persistentDataPath + "/Score/" + levelData.levelName + ".json", json);
                return;
            }
        }
        else //Creating a directory with a file which saves levelData
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Score"); //Creating directory
            string json = JsonUtility.ToJson(levelData);
            File.WriteAllText(Application.persistentDataPath + "/Score/" + levelData.levelName + ".json", json);
        }
    }
}
