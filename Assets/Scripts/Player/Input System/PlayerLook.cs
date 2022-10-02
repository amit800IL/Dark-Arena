using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    [SerializeField] float RotationSpeed;
    PlayerMovement playerMovement;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
      RotateInut(); 
    }

    public void RotateInut()
    {
        if (playerMovement.isGrounded)
        {
            transform.Rotate(0, InputManager.Instance.GetMouseDelta().x * RotationSpeed * Time.deltaTime, 0);
        }

    }
}
