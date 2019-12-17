using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlintStone : MonoBehaviour
{
    public int attackNum;
    private bool visited;
    public bool isFinalStone;
    public CombatMode combatMode;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag.Equals("Player") && !visited)
        {
            var curAtcks = other.gameObject.GetComponent<Attacks>();
            
            if (isFinalStone)
            {
                FinalStone();
            }
            //curAtcks.addAttack(atk);
            if (attackNum == 1)
            {
                curAtcks.hasAttack1 = true;
            }
            if (attackNum == 2)
            {
                curAtcks.hasAttack2 = true;
            }
            
            visited = true;
            
        }
    }

    void FinalStone()
    {
        combatMode.canBurnTrees = true;
    }
}
