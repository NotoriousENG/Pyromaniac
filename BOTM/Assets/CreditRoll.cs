using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditRoll : MonoBehaviour
{
    public float cTime = 10;
    public float speed = 1;
    private float waitTime;
    public string SceneName = "default";

    // Update is called once per frame
    private void Start() 
    {
        waitTime = Time.timeSinceLevelLoad + cTime;
    }
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (Time.timeSinceLevelLoad > waitTime)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
