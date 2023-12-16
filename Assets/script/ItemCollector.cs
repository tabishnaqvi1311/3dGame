using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int collectibleCount = 0;

    [SerializeField] Text coinText;
    [SerializeField] AudioSource collectSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            collectibleCount++;
            coinText.text = "Score: " + collectibleCount;
            collectSFX.Play();
            Destroy(other.gameObject);
        }
    }
}
