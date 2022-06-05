using UnityEngine;

[ExecuteInEditMode]
public class VisualSong : MonoBehaviour
{
    public AudioClip song;
    public float songLength;
    public GroundProperties ground;
    public float groundLength;

    void Start()
    {
        songLength = song.length;
        groundLength = songLength * ground.groundSpeed;
    }


    void Update()
    {
        //Drawing a ray to see how long the song is compared to the map length
        Debug.DrawRay((Vector2)transform.position, Vector2.right * groundLength, Color.blue);
    }
}
