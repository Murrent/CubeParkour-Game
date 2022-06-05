using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float jumpForce = 100.0f;
    public float rotationSpeed = -180.0f;
    public Vector2 scaleSize; //The size of the box collider
    private Rigidbody2D rb;
    private Transform parentObject;
    
    void Start()
    {
        parentObject = transform.parent;
        rb = parentObject.GetComponent<Rigidbody2D>();
    }
    void OnEnable() //Called when the Script is set as active
    {
        parentObject = transform.parent.transform;
        parentObject.GetComponent<BoxCollider2D>().size = scaleSize; //Setting the size of the box collider
    }
    
    void Update()
    {
        float gravity = parentObject.GetComponent<Rigidbody2D>().gravityScale;
        if (Input.GetButton("Jump") && parentObject.GetComponent<PlayerControls>().isGrounded) //Checking if the jump button is held down and the cube is on the ground
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * gravity); //Scaling the jumpforce with gravity so the jumpheight is always the same
        }
        if (!parentObject.GetComponent<PlayerControls>().isGrounded || Input.GetButton("Jump")) //Checking if the cube is in the air or if the Jump button is held down
        {
            //Rotating the visual object of the cube
            transform.GetComponent<Rigidbody2D>().freezeRotation = false;
            transform.GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed * gravity;
        }
        else
        {
            //Setting the rotation to default and freezing the rotation
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.GetComponent<Rigidbody2D>().freezeRotation = true;
        }
        transform.position = parentObject.position;
    }
}
