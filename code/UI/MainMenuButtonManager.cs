using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour
{
    public void LoadMenuScene() //Loads the scene named "Main menu"
    {
        SceneManager.LoadScene("Main menu");
    }
}
