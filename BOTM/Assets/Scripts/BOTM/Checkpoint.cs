using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public AudioSource src;
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag.Equals("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<Health>().respawnPos = transform.position;

            if (src.clip != clip)
            {
                src.clip = clip;
                src.Play();
            }
        }
    }
}
