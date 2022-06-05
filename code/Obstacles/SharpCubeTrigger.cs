using UnityEngine;

public class SharpCubeTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Sharp")
            transform.GetComponentInParent<PlayerControls>().shouldDie = true; //If the player (in cube state) hits a sharp object. The player should die
    }
}
