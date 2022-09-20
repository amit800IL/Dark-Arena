using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public DarkArenaNewInput inputActions;
    public UnityEvent onAttack;
    public UnityEvent onJump;
    public UnityEvent onRotation;
    public UnityEvent onClick;


    private void Start()
    {
        Instance = this;
        inputActions = new DarkArenaNewInput();
        inputActions.Enable();


        inputActions.Player.Attack.started += Attack_started;
        inputActions.Player.Jump.started += Jump_started;
        inputActions.Player.Rotate.started += Rotate_started;
        inputActions.UI.Click.started += Press_Started;

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

    private void Press_Started(InputAction.CallbackContext context)
    {
        onClick?.Invoke();
    }

    public Vector2 GetMoveInput()
    {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 getPressInput()
    {
        return inputActions.UI.Click.ReadValue<Vector2>();
    }


}
