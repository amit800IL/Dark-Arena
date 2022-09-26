using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] int movementState;
    public AudioSource zombieScream;
    [SerializeField] bool IsDamaged;


    [ContextMenu("Set State")]
    public void EnemyChaseState()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("Movement" , movementState);
        zombieScream.Play();    
    }
    
    [ContextMenu("Set Attack")]

    public void triggerAttack()
    {
        AttackState.attackingNow = true;
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Attack");
    }

    public void ResetAttackBool()
    {
        AttackState.attackingNow = false;

    }

    public void EnemyIsDamaged()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsDamaged", IsDamaged);
        
    }
}
