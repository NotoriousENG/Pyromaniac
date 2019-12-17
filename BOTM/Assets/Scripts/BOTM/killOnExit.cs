using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killOnExit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.name.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
