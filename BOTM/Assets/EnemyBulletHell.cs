using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHell : StateMachineBehaviour
{
    private Animator anim;
    public float deltaShoot = 1;
    private float nextTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim = animator;
        nextTime = Time.timeSinceLevelLoad + deltaShoot;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ProjectileHandler();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    private Weapon getEquipedWeapon()
    {
        return anim.gameObject.GetComponentInChildren<Weapon>();
    }

    private void ProjectileHandler()
    {
        float currTime = Time.timeSinceLevelLoad;
        if (nextTime < currTime)
        {
            nextTime = currTime + deltaShoot;
            createProjectile();
        }
    }
    private void createProjectile()
    {
        if (getEquipedWeapon() != null &&  getEquipedWeapon().isProjectileWeapon)
        {
            GameObject projSample = getEquipedWeapon().Projectile; // get the projectile to create

            /* **IF YOU ARE NOT USING THE MOUSE USE THIS** */
            Vector3 dir = new Vector3(anim.GetFloat("lastHorizontal"), anim.GetFloat("lastVertical"), 0); // get the direction to send the projectile into if you are not using the mouse

            GameObject proj = Instantiate<GameObject>(projSample) as GameObject; // create a new instance of the projectile (A copy/new bullet)
            proj.transform.position = anim.gameObject.transform.position; // set the origin position to the player's position
            proj.SetActive(true);

            MoveProjectile moveProjectile = proj.GetComponent<MoveProjectile>(); // get ready to setup the movement behaviour

            if (dir == new Vector3(0,0,0))
            {
                dir = new Vector3 (0,-1,0); // default to shooting down
            }
            moveProjectile.MoveDir = dir;
            moveProjectile.Shooter = anim.gameObject;

        }
    }
}
