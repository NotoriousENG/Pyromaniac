using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitPuzzle : MonoBehaviour
{
    public GameObject toggleObj;
    public bool setCond;
    private bool visited;

    private void Update() 
    {
        if (!visited)
        {
            int i = 0;
            foreach (Transform child in transform)
            {
                i++;
                if (child.gameObject.GetComponent<Torch>().isLit)
                {
                    i--;
                }
            }
            if (i == 0)
            {
                toggleObj.SetActive(setCond);
                visited = true;
            }
        }
    }
}
