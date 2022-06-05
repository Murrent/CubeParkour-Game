using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool defaultState = true; //Determines which Transform the object should have
    public float smoothness; //Speed of transition

    public Transform initial; //Default Transform

    public Transform final; //Final Transform
    
    public void FlipState()
    {
        defaultState = !defaultState; //Flips the defaultState bool
    }

    void Update() //Transforming the object smoothly to the initial of final depending on the defaultState
    {
        if (defaultState)
        {
            //Position
            transform.position = Vector2.Lerp(transform.position, initial.position, smoothness * Time.deltaTime);
            //Rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, initial.rotation, smoothness * Time.deltaTime);
            //Scale
            transform.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(transform.GetComponent<RectTransform>().sizeDelta, initial.GetComponent<RectTransform>().sizeDelta, smoothness * Time.deltaTime);
        }
        else
        {
            //Position
            transform.position = Vector2.Lerp(transform.position, final.position, smoothness * Time.deltaTime);
            //Rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, final.rotation, smoothness * Time.deltaTime);
            //Scale
            transform.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(transform.GetComponent<RectTransform>().sizeDelta, final.GetComponent<RectTransform>().sizeDelta, smoothness * Time.deltaTime);
        }
    }
}
