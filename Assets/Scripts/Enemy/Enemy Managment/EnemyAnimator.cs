using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimator : MonoBehaviour
{
    public AudioSource zombieScream;
    [SerializeField] int movementState;
    [SerializeField] bool IsDamaged;
    [SerializeField] private Animator animator;
    [SerializeField] MeshCollider EnemySwordCollider;
    [SerializeField] UnityEvent onAttackStart;
    [SerializeField] UnityEvent onAttackEnd;


    private void Update()
    {
        onAttackStart.AddListener(TurnOnWeaponColliders);
        onAttackEnd.AddListener(TurnOffWeaponColliders);
    }
    [ContextMenu("Set State")]
    public void EnemyChaseState()
    {

        animator.SetInteger("Movement", movementState);
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

    public void TurnOnWeaponColliders()
    {

        EnemySwordCollider.enabled = true;

    }

    public void TurnOffWeaponColliders()
    {

        EnemySwordCollider.enabled = false;
    }

    public void SetAttackStart()
    {
        onAttackStart?.Invoke();
    }

    public void SetAttackEnd()
    {
        onAttackEnd?.Invoke();
    }

}
