using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillMeter : MonoBehaviour
{
    private Meter meter;
    public bool isPlayer;

    private void Start() 
    {
        meter = GameObject.FindGameObjectWithTag("Player").GetComponent<Meter>();
        if (gameObject.tag.Equals("Player"))
        {
            isPlayer = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (((other.tag.Equals("Player") || other.tag.Equals("Weapon")) && !isPlayer) 
            || (other.tag.Equals("Projectile") && isPlayer))
        {
            meter.FillMeter();
        }
    }
}
