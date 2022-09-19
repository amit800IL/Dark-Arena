using UnityEngine;

public class AttackState : State
{
    [SerializeField]float attackRange = 0.5f;
    private Vector3 startingPosition;
    [SerializeField] EnemyAnimator EnemyAnimator;
    [SerializeField] Transform enemyPosition;

    public static bool attackingNow = false;
    private void Update()
    {
        RunCurrentState();
    }
    public override State RunCurrentState()
    {
        if (Vector3.Distance(enemyPosition.position, playerPosition.position) < attackRange)
        {
            if(!attackingNow)
            {
                EnemyAnimator.triggerAttack();
            }
        }

        return this;
    }
}
