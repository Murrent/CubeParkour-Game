using UnityEngine;
using UnityEngine.Tilemaps;
public class MoveGround : MonoBehaviour
{
    public DeathManager deathMan;
    private GroundProperties ground;
    private Rigidbody2D rb;
    private Tilemap tm;
    private bool startWinCalled = false;
    
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        UpdateSpeed();
        tm = transform.Find("Collision").GetComponent<Tilemap>(); //Getting the Tilemap in the gameobject child named Collision
    }
    public void UpdateSpeed()
    {
        ground = transform.GetComponentInParent<GroundProperties>(); //Gets the GroundProperties script from parent
        rb.velocity = new Vector2(-ground.groundSpeed, 0.0f); //Setting the velocity to the negative speed from the GroundProperties script
    }
    private void Update()
    {
        if (rb.velocity.x != -ground.groundSpeed) //If the velocity isnt equal to the groundspeed variable, we update it
            UpdateSpeed();
        if (!startWinCalled && tm.cellBounds.size.x < Mathf.Abs(transform.position.x)) //If the map has ended (the end of the tilemap is reached) we call the StartWin function
        {
            deathMan.StartWin();
            startWinCalled = true; //Stops the function from looping. We only want to call StartWin once.
        }
    }

}
