using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] int movementState;

    [ContextMenu("Set State")]
    public void setState()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("Movement" , movementState);
        
    }
    
    [ContextMenu("Set Attack")]

    public void triggerAttack()
    {

        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Attack");
    }
}
