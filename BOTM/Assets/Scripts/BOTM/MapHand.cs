using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHand : MonoBehaviour
{
    public Animator playerAnim;
    public Vector2 dirs;
    public float scale = 1;
    private Vector2 initPos;

    private void Start() 
    {
        initPos = transform.localPosition;
    }
    private void Update() 
    {
        dirs = new Vector2 (playerAnim.GetFloat("lastHorizontal"), playerAnim.GetFloat("lastVertical"));
        transform.localPosition = initPos + (dirs * scale);
        transform.localRotation = Quaternion.FromToRotation(Vector2.up, dirs);
    }
}
