using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    void Kill()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        var tag = other.gameObject.tag;
        if (tag.Equals("Weapon") || tag.Equals("Projectile"))
        {
            var combatMode = GameObject.Find("Player").GetComponent<CombatMode>();
            if (combatMode.isBlue && combatMode.canBurnTrees)
            {
                Kill();
            }
        }
    }
}
