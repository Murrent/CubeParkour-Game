using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonManager : MonoBehaviour
{
    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reloading the scene which is currently loaded
    }
}
