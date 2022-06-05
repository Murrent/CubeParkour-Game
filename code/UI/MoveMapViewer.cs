using UnityEngine;

public class MoveMapViewer : MonoBehaviour
{
    public bool inView = false; //determines if the object goes into view or not
    public float speed; //Speed of transition
    public Vector2 outPosition; //Out of view position

    private void Start()
    {
        outPosition = transform.position; //Initially, the object is out of view, so we set the outPosition to that current position
    }
    public void MoveIntoView()
    {
        inView = !inView; //Flips the inView bool state
    }
    void Update()
    {
        if (inView)
        {
            transform.position = Vector2.Lerp(transform.position, transform.parent.position, speed * Time.deltaTime); //Moves the object smoothly into the view
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, outPosition, speed * Time.deltaTime); //Moves the object smoothly out of the view
        }
    }
}
