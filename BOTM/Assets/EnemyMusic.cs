using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMusic : MonoBehaviour
{
    public AudioSource src;
    public AudioClip clip;
    private AudioClip prev;

    private void OnBecameVisible() {
        if (src.clip != clip)
        {
            prev = src.clip;
            src.clip = clip;
            src.Play();
        }
    }

    private void OnBecameInvisible() 
    {
        src.clip = prev;
        src.Play();
    }
}
