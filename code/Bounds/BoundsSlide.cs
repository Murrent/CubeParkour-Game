using UnityEngine;

public class BoundsSlide : MonoBehaviour
{
    public FollowPlayer cameraScript;
    public float smoothness;
    private Transform ground;
    private Transform roof;
    
    void Start()
    {
        ground = transform.Find("Ground");
        roof = transform.Find("Roof");
    }

    
    void Update()
    {
        ground.position = Vector2.Lerp(ground.position, new Vector2(0.0f, cameraScript.bottomLimit - 4.75f), smoothness * Time.deltaTime);
        roof.position = Vector2.Lerp(roof.position, new Vector2(0.0f, cameraScript.heightLimit + 4.75f), smoothness * Time.deltaTime);
    }
}
