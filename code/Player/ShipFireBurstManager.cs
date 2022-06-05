using UnityEngine;

//This script controls the flame on the ship state of the player

public class ShipFireBurstManager : MonoBehaviour
{
    public bool scaleSwitcher;
    //The scales to bounce between
    public Vector3 firstScale = new Vector3(0.6f, 0.8f, 1.0f);
    public Vector3 secondScale = new Vector3(0.8f, 0.6f, 1.0f); 
    public float speed; //Transition smoothness

    //The positions to bounce between
    private Vector3 firstPos;
    private Vector3 secondPos;
    private void Start()
    {
        firstPos = new Vector3(-0.9f, 0.0f, 0.0f);
        secondPos = new Vector3(-0.9f - (secondScale.x - 0.6f) / 2.0f, 0.0f, 0.0f);
    }


    private void Update()
    {
        if (scaleSwitcher)
        {
            //Smooth transition from current scale to firstScale, current position to firstPos
            transform.localScale = Vector3.Lerp(transform.localScale, firstScale, speed * Time.deltaTime);
            transform.localPosition = Vector3.Lerp(transform.localPosition, firstPos, speed * Time.deltaTime);
            if (transform.localScale.y >= firstScale.y - 0.01f) //Change direction if close to firstScale
                scaleSwitcher = false;
        }
        else
        {
            //Smooth transition from current scale to secondScale, current position to secondPos
            transform.localScale = Vector3.Lerp(transform.localScale, secondScale, speed * Time.deltaTime);
            transform.localPosition = Vector3.Lerp(transform.localPosition, secondPos, speed * Time.deltaTime);
            if (transform.localScale.x >= secondScale.x - 0.01f) //Change direction if close to secondScale
                scaleSwitcher = true;
        }
    }
}
