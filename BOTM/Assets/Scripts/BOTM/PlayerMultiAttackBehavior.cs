using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  #if UNITY_EDITOR
 using UnityEditor;
 #endif */

public class PlayerMultiAttackBehavior : StateMachineBehaviour
{
    public GameObject weapon;
    public Collider2D collider;
    public Weapon wep;
    public Animator weaponAnim;
    public Attacks AttackSet;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AttackSet = animator.gameObject.GetComponent<Attacks>();
        weapon = AttackSet.currAtk;
        wep = weapon.GetComponent<Weapon>();
        weapon.SetActive(true);
        weaponAnim = weapon.GetComponent<Animator>();
        weaponAnim.SetBool("isPlaying", true);
        animator.SetFloat("attackMultiplier", wep.Speed);
        createProjectile(animator);
        collider = weapon.GetComponent<Collider2D>();
        collider.enabled = true;

        if (animator.GetFloat("isBlue") > 0)
            {
                wep.canKillNPCs = true;
                wep.Power = 2;
            }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = 1; // return animator speed to default
        weaponAnim.SetBool("isPlaying", false);
        collider.enabled = false;
    }

    private void createProjectile(Animator animator)
    {
        if (wep != null &&  wep.isProjectileWeapon)
        {
            GameObject projSample = wep.Projectile; // get the projectile to create

            /* **IF YOU ARE NOT USING THE MOUSE USE THIS** */
            Vector3 dir = new Vector3(animator.GetFloat("lastHorizontal"), animator.GetFloat("lastVertical"), 0); // get the direction to send the projectile into if you are not using the mouse

            GameObject proj = Instantiate<GameObject>(projSample) as GameObject; // create a new instance of the projectile (A copy/new bullet)
            proj.transform.position = animator.gameObject.transform.position; // set the origin position to the player's position
            proj.SetActive(true);

            MoveProjectile moveProjectile = proj.GetComponent<MoveProjectile>(); // get ready to setup the movement behaviour

            if (animator.GetFloat("isBlue") > 0)
            {
                moveProjectile.canKillNPCs = true;
                moveProjectile.Power = 2;
            }

            /*  **IF YOU ARE USING THE MOUSE USE THIS** 
            Vector3 screenPos = Camera.main.WorldToScreenPoint(animator.gameObject.transform.position); // take into account the camera space if you are using the mouse
            dir = (Input.mousePosition - screenPos).normalized;
            */

            if (dir == new Vector3(0,0,0))
            {
                dir = new Vector3 (0,-1,0); // default to shooting down
            }
            moveProjectile.MoveDir = dir;
            moveProjectile.Shooter = animator.gameObject;

        }
    }

}