using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this namespace lets us access scene management
using UnityEngine.SceneManagement;

public class PlayerLifeScript : MonoBehaviour
{
    bool dead = false;

    [SerializeField] AudioSource DeathSFX;

    private void OnCollisionEnter(Collision collision)
    {
        //we added a tag, not the name
        //and used it to refer to the enemy
        //as name may be different
        if (collision.gameObject.CompareTag("EnemyBody"))
        {
            handleDeath();
        }
    }

    void Update()
    {
        if (transform.position.y < -5 && !dead) handleDeath();

    }

    void handleDeath()
        //make player disappear and remove all physics and reload the game after an interval of time
    {
        //for removing player from scene, we disable the mesh renderer component
        GetComponent<MeshRenderer>().enabled = false;
        //for disabling the physics, change the rigidBody isKinematic prop to true, wont be pushed around
        GetComponent<Rigidbody>().isKinematic = true;
        //stop movement by disabling the movement script
        GetComponent<playerMovement>().enabled = false;

        //we could also use destroy the gameobject, but we wont be able to reload the game
        DeathSFX.Play();
        ReloadLevel();
        dead = true;
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
