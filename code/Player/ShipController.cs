using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Vector2 scaleSize; //The size to set the collider to
    public float flyThrust;
    public float targetRotation;
    public float lerpSmoothness;
    private GameObject playerObject;
    void Start()
    {
        playerObject = transform.parent.gameObject;
    }
    void OnEnable()
    {
        playerObject = transform.parent.gameObject;
        playerObject.GetComponent<BoxCollider2D>().size = scaleSize; //Setting the right size on the collider
    }
    void Update()
    {
        if (Input.GetButton("Jump")) //Adding force upward as long as the jump key is pressed
        {
            playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, flyThrust * Time.deltaTime));
        }
        //Calculating how much the ship should rotate 
        targetRotation = 5 * playerObject.GetComponent<Rigidbody2D>().velocity.y;
        //Stopping the ship from rotating too much
        if (targetRotation > 75) targetRotation = 75;
        else if (targetRotation < -75) targetRotation = -75;
        //Lerp from current rotation to target rotation for a smoother experience
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, targetRotation), lerpSmoothness * Time.deltaTime);
    }
}
