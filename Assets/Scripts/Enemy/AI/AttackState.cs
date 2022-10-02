using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{

    public static bool attackingNow = false;
    [SerializeField] EnemyAnimator EnemyAnimator;
    [SerializeField] ChaseState chaseState;
  
    
    public override State RunCurrentState()
    {

        if (!attackingNow)
        {
           
            EnemyAnimator.triggerAttack();
        }
        if (!chaseState.isInAttackRange)
        {
            return chaseState;
        }
        return this;


    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player") && attackingNow == true)
        {
          
            PlayerStats.Instance.healthManager.TakeDamage(2);
        }
    }

    

}
