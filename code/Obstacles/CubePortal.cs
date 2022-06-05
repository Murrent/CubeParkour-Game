using UnityEngine;

public class CubePortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.transform.tag == "PlayerVisual")
            //Calling the UpdateState function and setting the state enum to cube
            collider.GetComponentInParent<PlayerControls>().UpdateState(PlayerControls.State.cube);
    }
}
