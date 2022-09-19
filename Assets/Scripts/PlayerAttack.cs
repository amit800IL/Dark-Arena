using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class PlayerAttack : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField] LayerMask groundMask;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundDistance;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] MeshCollider SwordCollider;
    [SerializeField] MeshCollider DaggerCollider;
    public UnityEvent onAttackStart;
    public UnityEvent onAttackEnd;
    public AudioSource AttackVoice;
    private void Start()
    {


        rb = GetComponent<Rigidbody>();
        InputManager.Instance.onAttack.AddListener(AttackInput);

       onAttackStart.AddListener(TurnOnWeaponColliders);
       onAttackEnd.AddListener(TurnOffWeaponColliders);

    }

    public void AttackInput()
    {
        if (playerMovement.isGrounded)
        {
            Attack();
        }
    }
    public void Attack()
    {
        playerMovement.playerAnimator.Play("Attack");
        AttackVoice.Play();

    }

    public void SetAttackStart()//called by animation event
    {
        onAttackStart?.Invoke();
    }

    public void SetAttackEnd()//called by animation event
    {
        onAttackEnd?.Invoke();
    }

    public void TurnOnWeaponColliders()
    {
        SwordCollider.enabled = true;
        DaggerCollider.enabled = true;
    }

    public void TurnOffWeaponColliders()
    {
        SwordCollider.enabled = false;
        DaggerCollider.enabled = false;
    }

}
