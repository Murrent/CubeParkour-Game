using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; //Player transform
    public float smoothness; //Transition smoothness
    public float heightLimit = 0.0f; //How high the camera can go on the y-axis
    public float bottomLimit = 0.0f; //How low the camera can go on the y-axis

    void FixedUpdate()
    {
        //Keeping the camera inside the limits
        //If its in limits, its moving towards the player's y position
        float playPos = 0.0f;
        if (player.position.y < bottomLimit) 
            playPos = bottomLimit;
        else if (player.position.y > heightLimit)
            playPos = heightLimit;
        else
            playPos = player.position.y;
        Vector2 desired = new Vector2(transform.position.x, playPos); //Desired position gets the modified y pos
        Vector2 current = transform.position; 
        transform.position = Vector2.Lerp(current, desired, smoothness * Time.deltaTime); //Moving smoothly to the desired position
    }
}
