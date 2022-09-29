using UnityEngine;

public class AttackState : State
{

    [SerializeField] EnemyAnimator EnemyAnimator;
    [SerializeField] ChaseState chaseState;
    public static bool attackingNow = false;

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
        if (other.gameObject.CompareTag("Player"))
        {

            PlayerStats.Instance.healthManager.TakeDamage(2);
        }
    }
}