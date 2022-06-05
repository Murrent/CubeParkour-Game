using UnityEngine;

[ExecuteInEditMode]
public class DebugFloor : MonoBehaviour
{
    public Vector2 offset = Vector2.zero;

    void Update()
    {
        //Drawing a ray in editor to see where the floor is
        Debug.DrawRay((Vector2)transform.position + offset, Vector2.right * 1000.0f, Color.red);
    }
}
