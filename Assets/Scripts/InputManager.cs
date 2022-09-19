using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public BreakOutNewInput inputActions;
    public UnityEvent onAttack;
    public UnityEvent onJump;
    public UnityEvent onRotation;


    private void Start()
    {
        Instance = this;
        inputActions = new BreakOutNewInput();
        inputActions.Enable();


        inputActions.Player.Attack.started += Attack_started;
        inputActions.Player.Jump.started += Jump_started;
        inputActions.Player.Rotate.started += Rotate_started;
    }

    private void Rotate_started(InputAction.CallbackContext context)
    {
        onRotation?.Invoke();
    }

    private void Jump_started(InputAction.CallbackContext context)
    {
        onJump?.Invoke();
    }

    private void Attack_started(InputAction.CallbackContext context)
    {
        onAttack?.Invoke();
    }

    public Vector2 GetMoveInput()
    {
        return inputActions.Player.Move.ReadValue<Vector2>();   
    }
    
}
