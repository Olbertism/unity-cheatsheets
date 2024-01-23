using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int counter = 0;
    [SerializeField] TextMeshProUGUI collectibleText;
    [SerializeField] AudioSource coinsAudioSource;

    // OnCollisionEnter only works for non isTrigger Colliders. With triggers we need:
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            counter++;
            collectibleText.text = "Collectibles: " + counter.ToString();
            coinsAudioSource.Play();
        }
    }
}