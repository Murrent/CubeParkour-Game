using UnityEngine;

public class SharpShipTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Sharp")
            transform.GetComponentInParent<PlayerControls>().shouldDie = true; //The visual ship is currently touching a sharp tile and should die
        else if (collider.transform.tag == "Block")
            transform.GetComponentInParent<PlayerControls>().spriteHitBlock = true; //The visual ship object is currently touching a block
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Block")
            transform.GetComponentInParent<PlayerControls>().spriteHitBlock = false; //The visual ship object is no longer touching a block
    }
}
