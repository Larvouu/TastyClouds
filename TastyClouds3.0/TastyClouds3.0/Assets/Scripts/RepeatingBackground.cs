using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour
{

    /*  private BoxCollider2D groundCollider;*/       //This stores a reference to the collider attached to the Ground.
    private int groundHorizontalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.

    //Awake is called before Start.
    private void Awake()
    {
        groundHorizontalLength = 45;
    }
    //Update runs once per frame
    private void Update()
    {
        if (transform.position.x < - 40)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        transform.position = new Vector2(groundHorizontalLength , transform.position.y);
    }
}

