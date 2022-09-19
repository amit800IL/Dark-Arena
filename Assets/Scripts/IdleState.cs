public class IdleState : State
{
    public ChaseState chastState;
    public bool canSeePlayer;

    private void Update()
    {
        RunCurrentState();
    }
    public override State RunCurrentState()
    {
        if (canSeePlayer)
        {
            return chastState;

        }
        else
        {
            return this;
        }
    }
       
    }


