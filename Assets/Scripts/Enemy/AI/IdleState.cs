using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;
    public bool canSeePlayer;
    public LayerMask PlayerLayer;
    [SerializeField] float sightRange;
    public override State RunCurrentState()
    {
        canSeePlayer = Physics.Raycast(transform.position, (playerPosition.position - transform.position).normalized, sightRange, PlayerLayer);
        if (canSeePlayer)
        {
            return chaseState;

        }
        else
        {
            return this;
        }
    }
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, (playerPosition.position - transform.position).normalized * sightRange);
    }
}


