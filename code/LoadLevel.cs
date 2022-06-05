using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string sceneName;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName); //Loads the scene named as the string
    }
}
