using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public BreakOutNewInput inputActions;

    public Animator playerAnimator;



    [Header("Physhics")]

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    Rigidbody rb;
    Vector2 moveInput;
    Vector3 newMove;
    Vector3 JumpForce;

    [Header("Ground Check")]

    [SerializeField] Camera playerCamera;
    [SerializeField] LayerMask groundMask;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundDistance;
    public bool isGrounded;
    private float blendX, blendY;
    public float blendSpeed;

    private void Awake()
    {

        inputActions = new BreakOutNewInput();
        rb = GetComponent<Rigidbody>();
        inputActions.Player.Enable();
        inputActions.Player.Jump.started += JumpInput;
        inputActions.Player.Attack.started += AttackInput;
        inputActions.Player.Rotate.started += RotateInput;


    }


    private void Update()
    {
        IsGrouded();


        moveInput = inputActions.Player.Move.ReadValue<Vector2>();
        newMove = moveInput.x * transform.right + moveInput.y * transform.forward;
        if (newMove.magnitude > 1)
            newMove.Normalize();
        blendX = Mathf.MoveTowards(blendX, moveInput.x, blendSpeed * Time.deltaTime);
        blendY = Mathf.MoveTowards(blendY, moveInput.y, blendSpeed * Time.deltaTime);


        if (rb.velocity == Vector3.zero)
        {
            playerAnimator.SetBool("IsMoving", false);


        }
        else
        {
            if (rb.velocity.y < 0)
            {
                playerAnimator.SetBool("IsJump", false);
            }

            playerAnimator.SetBool("IsMoving", true);

        }
        playerAnimator.SetFloat("verticleTEST", blendY);
        playerAnimator.SetFloat("horizontalTEST", blendX);



    }

    private void FixedUpdate()
    {
        if (newMove != null)
        {
            rb.AddForce(newMove * speed, ForceMode.Impulse);
        }
    }



    public void Jump()
    {

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        playerAnimator.SetBool("IsJump", true);


    }
    public void AttackInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && isGrounded)
        {
            Attack();
        }
    }
    public void Attack()
    {
        playerAnimator.Play("Attack");

    }


    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && isGrounded)
        {
            Jump();
        }
    }

    public void Rotate()
    {

        float targetAngle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, blendSpeed * Time.deltaTime);

    }

    public void RotateInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && isGrounded)
        {
            Rotate();
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && isGrounded)
        {
            playerAnimator.Play("Attack");

        }
    }


    public void IsGrouded()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);

        if (!isGrounded)
        {
            playerAnimator.SetBool("IsJump", false);

        }
    }

}
