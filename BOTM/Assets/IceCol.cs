using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCol : MonoBehaviour
{
    public GameObject[] enables;
    public GameObject[] disables;

    private void MySwitch(GameObject[] gameObjects, bool setVal)
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(setVal);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag.Equals("Ice"))
        {
            MySwitch(enables, true);
            MySwitch(disables,false);
        }
    }
}
