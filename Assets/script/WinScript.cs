using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            //go to next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //end the game if levels over
        }
    }
}
