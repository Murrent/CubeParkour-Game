using UnityEngine;

public class ShipPortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "PlayerVisual")
            collider.GetComponentInParent<PlayerControls>().UpdateState(PlayerControls.State.ship); //If the visual object of the player is entering the portal collider, we update the state to ship
    }
}
