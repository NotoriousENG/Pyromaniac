using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGauntlet : MonoBehaviour
{
    public Health[] healths;
    public GameObject[] toggleObjs;
    public bool setToggleTo = true;
    private bool visited;
    private void Update() 
    {
        if (!visited)
        {
            int i = 0;
            foreach (Health health in healths)
            {
                i++;
                if (health == null || health.current <= 0 || !health.gameObject)
                {
                    i--;
                }
            }
            if (i == 0)
            {
                visited = true;
                foreach (GameObject toggleObj in toggleObjs)
                {
                    toggleObj.SetActive(setToggleTo);
                }
                gameObject.SetActive(false);
            }
        }
    }
}
