using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public List<GameObject> availiableAttacks;
    public Transform hand;
    public GameObject currAtk;
    public bool hasAttack1;
    public bool hasAttack2;

    private void Start() 
    {
        if (availiableAttacks.Count != 0)
        {
            foreach (GameObject atk in availiableAttacks)
            {
                atk.transform.parent = hand;
            }
            currAtk = availiableAttacks[0];
        }
    }

    private void Update() 
    {
        setCurrAttack();    
    }
    public void addAttack(GameObject atk)
    {
        availiableAttacks.Add(atk);
        availiableAttacks[availiableAttacks.Count].transform.parent = hand;
    }

    public void setCurrAttack()
    {
        int i = 0;
        if (Input.GetButtonDown("Fire1"))
        {
            i = 0;
            currAtk = availiableAttacks[i];
        }
        else if (Input.GetButtonDown("Fire2") && hasAttack1)
        {
            i = 1;
            currAtk = availiableAttacks[i];
        }
        else if (Input.GetButtonDown("Fire3") && hasAttack2)
        {
            i = 2;
            currAtk = availiableAttacks[i];
        }
    }
}
