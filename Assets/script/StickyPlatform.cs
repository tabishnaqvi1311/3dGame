using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //built in method for checking collision
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "player")
        {
            //make the player a child of the moving platform
            //so player moves together with it
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            //remove the player child
            collision.gameObject.transform.SetParent(null);
        }
    }
}
