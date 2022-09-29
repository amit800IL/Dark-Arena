using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] int movementState;
    public AudioSource zombieScream;
    [SerializeField] bool IsDamaged;
    [SerializeField]private Animator animator;


    [ContextMenu("Set State")]
    public void EnemyChaseState()
    {
        
        animator.SetInteger("Movement" , movementState);
        zombieScream.Play();    
    }
    
    [ContextMenu("Set Attack")]

    public void triggerAttack()
    {
        AttackState.attackingNow = true;
        animator.SetTrigger("Attack");
    }

    public void ResetAttackBool()
    {
        AttackState.attackingNow = false;

    }

    public void EnemyIsDamaged()
    {
        animator.SetTrigger("IsDamaged");
        
    }
}