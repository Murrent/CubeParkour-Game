using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public enum State { cube, ship }
    private State state = State.cube;

    public GameObject cubeObject;
    public GameObject shipObject;

    private GameObject groundedOn = null;

    public bool isGrounded = false;
    public bool shouldDie = false;
    public bool thisHitBlock = false; //Used for more responsive collision detection
    public bool spriteHitBlock = false; //Used for more responsive collision detection

    private bool inRangeOfClickable = false;
    private GameObject clickableObject;

    private bool deathHasBeenCalled = false;

    public FollowPlayer cameraScript;
    void Update()
    {
        //If deathHasBeenCalled is true we skip this statement
        //shouldDie = death guaranteed
        //thisHitBlock = player collider is hitting a another collider
        //spriteHitBlock = visual player is hitting a block
        if (!deathHasBeenCalled && (shouldDie || thisHitBlock && spriteHitBlock))
        {
            gameObject.GetComponent<DeathManager>().StartDeath(); //Beginning death
            deathHasBeenCalled = true; //Stopping the function from looping
        }

        if (inRangeOfClickable && Input.GetButtonDown("Jump")) //Checking if we are pressing Jump while in range of a clickable object
        {
            float gravity = transform.GetComponent<Rigidbody2D>().gravityScale; //GravityScale of the player
            ClickJump otherScript = clickableObject.GetComponent<ClickJump>(); //ClickJump script from the clickableObject
            otherScript.beenUsed = true; //The clickableObject has now been used
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, otherScript.jumpBoost * gravity); //Changing the player velocity depending on the jumpboost float of the clickableObject

            if (otherScript.invertGravity) //Inverts the gravity of the player's rigidbody if the clickableObject's bool is true
            {
                transform.GetComponent<Rigidbody2D>().gravityScale = -gravity;
            }
        }
    }
    public void UpdateState(State newState) //Changes the state of the player
    {
        state = newState;
        if (newState == State.cube)
        {
            //Switching to the Cube object
            cubeObject.SetActive(true);
            shipObject.SetActive(false);
            //Setting the position of the ground and the roof
            cameraScript.heightLimit = 50.0f; 
            cameraScript.bottomLimit = 0.0f;
        }
        else if (newState == State.ship)
        {
            //Switching to the Ship object
            cubeObject.SetActive(false);
            shipObject.SetActive(true);
            //Moving the roof limit down
            cameraScript.heightLimit = 0.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.transform.tag == "Block" || theCollision.transform.tag == "Ground") //Checking if theCollision from the tilemap "Block" or the bottom/top borders "Ground"
        {
            foreach (ContactPoint2D contact in theCollision.contacts) //Looping through contactpoints
            {
                if (state == State.cube && contact.normal.y > 0.9f * transform.GetComponent<Rigidbody2D>().gravityScale) //The normal on the y axis should be more than 0.9 (pointing upwards) to tell we are grounded on a flat ground
                {
                    isGrounded = true; //Now the cube is on the ground
                    groundedOn = theCollision.gameObject; //Keeping the object so we can check if we leave it later
                }
                //The ship can be grounded on a roof or a floor
                else if (state == State.ship && contact.normal.y > 0.9f || contact.normal.y < -0.9f)
                {
                    isGrounded = true;
                    groundedOn = theCollision.gameObject;
                }
                //If the contact point is anything else, that means we hit a tile from the side which means we should die
                else
                {
                    shouldDie = true;
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D theCollision)
    {
        if (theCollision.transform.tag == "Block" && theCollision.gameObject.GetComponent<Rigidbody2D>().isKinematic) //The collision tilemap has tag Block. We also only want kinematic rigidbodies
        {
            foreach (ContactPoint2D contact in theCollision.contacts) //Looping through each contactpoint
            {
                //The normal on the y axis should be more than or equal to 0.9 (pointing upwards) which means we are standing on a flat ground. 
                //If gravity is inverted, it should be less than -0.9 (pointing downwards) Else we should die
                if (state == State.cube && (
                    (transform.GetComponent<Rigidbody2D>().gravityScale == 1.0f && contact.normal.y < 0.9f) || 
                    (transform.GetComponent<Rigidbody2D>().gravityScale == -1.0f && contact.normal.y > -0.9f)
                    )) 
                {
                    shouldDie = true;
                }
                //If we are in ship state, we are allowed to touch the floor and the roof
                else if (state == State.ship && contact.normal.y < 0.9f && contact.normal.y > -0.9f)
                {
                    shouldDie = true;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject == groundedOn) //Checking if the player is exiting collision which its standing on
        {
            //The player is currently not standing on a safe position or is in the air
            groundedOn = null;
            isGrounded = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ClickJump" && !collision.GetComponent<ClickJump>().beenUsed)
        {
            //A clickable object is in range of the player
            inRangeOfClickable = true;
            clickableObject = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ClickJump")
        {
            //Theres no longer a clickable object in range
            inRangeOfClickable = false; 
            clickableObject = null;
        }
    }
}
