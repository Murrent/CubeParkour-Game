using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    public ParticleSystem deathParticle;
    public List<GameObject> visuals;
    public float timeAfterDeath;
    public GroundProperties groundProperties;
    public MoveGround moveGround;
    public AudioSource song;
    public bool endSong = false;
    public float endSongSpeed;

    public bool winStarted = false;
    public Transform winWall;
    public float winWallTransitionSpeed;
    //Variables for saving the game data into files
    public ScoreManager scoreMan;

    public Scene mainMenuScene;

    private void Update()
    {
        if (endSong)
        {
            song.pitch = Mathf.Lerp(song.pitch, 0.0f, endSongSpeed * Time.deltaTime); //Smoothly lowering the pitch to 0
        }
        if (winStarted)
        {
            winWall.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(
                winWall.GetComponent<RectTransform>().anchoredPosition, 
                new Vector3(0, 0, 0), 
                winWallTransitionSpeed * Time.deltaTime);
        }
    }
    public void StartDeath()
    {
        scoreMan.Save(); //Saving score into a file
        deathParticle.Play(); //Playing the particlesystem for death effect
        groundProperties.groundSpeed = 0; //Ground should not move
        moveGround.UpdateSpeed(); //Update the ground velocity
        endSong = true; //Setting this to true will smoothly end the song
        for (int i = 0; i < visuals.Count; i++) //Turning the player's visual objects inactive
        {
            visuals[i].SetActive(false);
        }
        winStarted = true;
        winWall.Find("WinText").GetComponent<Text>().text = "YOU LOST";
        //StartCoroutine(WaitThenLoadScene(timeAfterDeath, SceneManager.GetActiveScene().buildIndex)); //Wait and reload same scene
    }
    private IEnumerator WaitThenLoadScene(float waitTime, int scene)
    {
        yield return new WaitForSeconds(waitTime); //Waiting for "waitTime" seconds then executing code below
        SceneManager.LoadScene(scene); //Reloading the same scene
    }
    public void StartWin()
    {
        scoreMan.levelData.score = 1.0f; //setting the score to max = 1
        scoreMan.Save(); //Saving score and level properties into file
        deathParticle.Play(); //Playing the particlesystem for death effect
        groundProperties.groundSpeed = 0; //Ground should not move
        moveGround.UpdateSpeed(); //Update the ground velocity
        for (int i = 0; i < visuals.Count; i++) //Turning the player's visual objects inactive
        {
            visuals[i].SetActive(false);
        }
        winStarted = true;
        winWall.Find("WinText").GetComponent<Text>().text = "CONGRATULATIONS!\n100%";
        //StartCoroutine(WaitThenLoadScene(timeAfterDeath, 1)); //Wait and load the main menu
    }
}
