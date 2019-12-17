using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : MonoBehaviour
{
    private CombatMode playerMode;
    public float meltAmt = .1f;
    private Vector3 oScale;
    private Vector3 oPos;

    private void Start() 
    {
        playerMode = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatMode>();
        oScale = transform.localScale;
        oPos = transform.position;
    }
    

    private void Melt(float extraScale)
    {
        if (transform.localScale.x >= .3)
        {
            transform.localScale -=  oScale * meltAmt * extraScale * Time.deltaTime;
        }
        else
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.localScale = oScale;
        transform.position = oPos;
    }


    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag.Equals("Weapon") || other.tag.Equals("Projectile") ||
                (other.tag.Equals("Player") && playerMode.isBlue))
        {
            Melt(1);
        }
        else if (other.tag.Equals("Player"))
        {
            Melt(0.1f);
        }
    }
}
