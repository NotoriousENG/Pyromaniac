using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool isLit;
    // private Animator animator;

    /* private void Start() 
    {
        animator = GetComponent<Animator>();
    } */

    /* void SetAnimBool()
    {
        animator.SetBool("isLit", isLit);
    }
 */
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag.Equals("Weapon") || other.tag.Equals("Projectile"))
        {
            isLit = true;
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(true);
            }
            // SetAnimBool();
        }
    }
}
