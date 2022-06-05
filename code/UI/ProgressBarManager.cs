using UnityEngine;
using UnityEngine.UI;
public class ProgressBarManager : MonoBehaviour
{
    public VisualSong song;
    public Transform ground;
    public ScoreManager scoreMan;
    public float levelLengthOffset = 0.0f;
    void Update()
    {
        scoreMan.levelData.score = Mathf.Abs(ground.position.x) / (song.groundLength + levelLengthOffset); //Calculating score depending on distance 
        transform.GetComponent<Slider>().value = scoreMan.levelData.score; //Adding the score to the slider
    }
}
