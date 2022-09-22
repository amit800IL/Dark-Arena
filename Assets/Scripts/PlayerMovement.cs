using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


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

    private void Start()
    {


        rb = GetComponent<Rigidbody>();

        InputManager.Instance.onJump.AddListener(JumpInput);



    }


    private void Update()
    {
        IsGrouded();


        moveInput = InputManager.Instance.GetMoveInput();
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



    public void JumpInput()
    {
        if (isGrounded)
        {
            Jump();
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
