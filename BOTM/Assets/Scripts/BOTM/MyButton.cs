using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : MonoBehaviour
{
    private Animator animator;
    public bool isPressed;
    public bool isStatic;
    public bool setBool = true;
    public GameObject toggleObj;

    private void Start() 
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isPressed", isPressed);
        setObjectActive();
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag.Equals("Player"))
        {
            isPressed = true;
            setAnimatorParams();
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag.Equals("Player") && !isStatic)
        {
            isPressed = false;
            setAnimatorParams();
        }
    }

    void setAnimatorParams()
    {
        animator.SetBool("isPressed", isPressed);
        setObjectActive();
    }

    void setObjectActive()
    {
        toggleObj.SetActive(isPressed.Equals(setBool));
    }
}
