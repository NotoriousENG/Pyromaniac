using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject[] gameObjects;

    void ObjSetting(bool value, Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.SetActive(value);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        ObjSetting(true, other);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        ObjSetting(false,other);
    }
}
