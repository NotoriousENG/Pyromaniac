﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMode : MonoBehaviour
{
    public bool isBlue;
    public bool canBurnTrees;
    public Color Blue;
    private Color curr, prev;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Weapon weapon;

    private void Start() 
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        curr = spriteRenderer.color;
        prev = Blue;  
    }
    private void Update() 
    {
        if (Input.GetButtonDown("Trigger"))
        {
            isBlue = !isBlue;
            int tmp = 0;
            if (isBlue)
            {
                tmp = 1;
            }
            animator.SetFloat("isBlue", tmp);
            
            changeColor();
        }   
    }

    public void changeColor()
    {
        spriteRenderer.color = prev;

        var tmp = curr;
        curr = prev;
        prev = tmp;
    }
}
