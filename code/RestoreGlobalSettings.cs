using UnityEngine;

public class RestoreGlobalSettings : MonoBehaviour
{
    void Start()
    {
        // Corrects the timescale. (This was implemented to update 
        // the timeScale when loading a new scene.
        // Since timeScale is a global variable across all scenes)
        Time.timeScale = 1.25f; 
    }
}
