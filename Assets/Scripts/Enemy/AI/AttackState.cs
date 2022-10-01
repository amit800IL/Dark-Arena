using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{

    [SerializeField] EnemyAnimator EnemyAnimator;
    [SerializeField] ChaseState chaseState;
    public static bool attackingNow = false;
  
    
    private void Start()
    {
        
    }
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
