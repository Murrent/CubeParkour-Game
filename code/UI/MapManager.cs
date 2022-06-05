using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public GameObject levelButtonAsset; //The prefab for a levelbutton
    
    void Start()
    {
        GetComponent<LevelFilesManager>().VerifyAllFiles();
        LoadAllLevels(); //Loading all levels into the main menu UI
    }

    public void LoadAllLevels()
    {
        //Checking if the folder with levels exists
        if (!Directory.Exists(Application.persistentDataPath + "/Score"))
            return;
        //Saving the file paths to each level
        string[] levels = Directory.GetFiles(Application.persistentDataPath + "/Score");

        for (int i = 0; i < levels.Length; i++) //Looping through the files
        {
            string json = File.ReadAllText(levels[i]); //Grabbing the data from the file into a string
            CreateLevelButton(JsonUtility.FromJson<LevelDataClass>(json)); //Converting the data to a LevelDataClass datatype and calling the CreateLevelButton function with it as parameter
        }

    }

    public void CreateLevelButton(LevelDataClass levelData)
    {
        float offset = 0.0f;
        float sideOffset = 200.0f;
        switch (levelData.levelID) //Determining the x position by the levelID. 0 = first level, 1 = second level etc...
        {
            case 0:
                offset = -sideOffset;
                break;
            case 2:
                offset = sideOffset;
                break;
        }
        //Creating a new object with the prefab
        GameObject levelButton = Instantiate(levelButtonAsset, transform);
        //Grabbing the UI transform of the button
        RectTransform buttonTransform = levelButton.GetComponent<RectTransform>();
        //Adding offset to the position. anchoredPosition is the correct unit for RectTranforms
        buttonTransform.anchoredPosition = new Vector2(buttonTransform.anchoredPosition.x + offset, buttonTransform.anchoredPosition.y);
        //Setting title in the object
        levelButton.transform.Find("Title").GetComponent<Text>().text = levelData.levelName;
        //Setting difficulty 
        levelButton.transform.Find("Difficulty").Find("DynamicText").GetComponent<Text>().text = levelData.GetDifficultyDisplayName();
        //Setting progress bar value
        levelButton.transform.Find("Progress").Find("Slider").GetComponent<Slider>().value = levelData.score;
        //Setting progress percentage text
        levelButton.transform.Find("Progress").Find("Static Progress Text").GetComponent<Text>().text = "Progress: " + Mathf.FloorToInt(levelData.score * 100.0f) + "%";
        //Setting scene name so the button knows what to load on press
        levelButton.GetComponent<LoadLevel>().sceneName = levelData.levelName;
    }
}
