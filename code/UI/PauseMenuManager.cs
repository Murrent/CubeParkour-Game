using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public Transform pauseMenu;
    public bool openMenu;
    public float outPosY;
    public float speed;
    public AudioSource song;

    public DeathManager deathM;
    private void Start()
    {
        outPosY = pauseMenu.localPosition.y; //Initially, the menu is outside the camera so we grab that y position
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !deathM.winStarted) //Pauses/unpauses the game 
        {
            SwitchPause();
        }
        if (openMenu)
            OpenMenuHandler();
        else
            CloseMenuHandler();
    }

    public void SwitchPause()
    {
        openMenu = !openMenu;
        if (openMenu && song.isPlaying) //Checking so the menu is open and the song is playing before pausing the music
            song.Pause();
        else
            song.Play();
    }

    private void OpenMenuHandler()
    {
        Time.timeScale = 0.0f; //Stops simulating 
        pauseMenu.localPosition = Vector2.Lerp(pauseMenu.localPosition, new Vector2(0, 0), speed * Time.fixedDeltaTime); //Smooth transition to the open position
    }
    private void CloseMenuHandler()
    {
        Time.timeScale = 1.0f; //Setting the timescale to normal to keep simulating physics etc.
        pauseMenu.localPosition = Vector2.Lerp(pauseMenu.localPosition, new Vector2(0, outPosY), speed * Time.fixedDeltaTime); //Smooth transition to the closed position
    }
}
