using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public bool save;
    public LevelDataClass levelData;

    private void Start()
    {
        levelData.levelName = SceneManager.GetActiveScene().name;
        levelData = Load();
    }

    private void Update()
    {
        if (save) Save();
        save = false;
    }

    public void Save()
    {
        //Checking if the directory and the file exists
        if (Directory.Exists(Application.persistentDataPath + "/Score") && System.IO.File.Exists(Application.persistentDataPath + "/Score/" + levelData.levelName + ".json"))
        {
            //If the file has more or same score as levelData.score, we want to quit saving
            if (Load().score >= levelData.score)
                return;
        }
        
        string json = JsonUtility.ToJson(levelData); //Converting levelData into a json string
        if (!Directory.Exists(Application.persistentDataPath + "/Score")) //Checking if the directory doesn't exists...
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Score"); //if not, we create it.
        }
        File.WriteAllText(Application.persistentDataPath + "/Score/" + levelData.levelName + ".json", json); //Writing the string into a file saved with the levelName as name
    }

    public LevelDataClass Load()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/Score/" + levelData.levelName + ".json"); //Copying the file's content into a new string
        return JsonUtility.FromJson<LevelDataClass>(json); //Converting the string data into a LevelDataClass datatype and returning it.
    }
}
