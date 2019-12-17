using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInCollider : MonoBehaviour
{
    public AudioSource src;
    public AudioClip clip;
    private AudioClip prev;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        prev = src.clip;
        src.clip = clip;
        src.Play();
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        src.clip = prev;
        src.Play();
    }
}
