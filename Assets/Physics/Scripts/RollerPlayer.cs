using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]

public class RollerPlayer : MonoBehaviour
{
    [SerializeField, Range(0, 50)] float moveForce = 3;
    [SerializeField, Range(0, 50)] float jumpForce = 3;

    Rigidbody rb;
    Vector2 inputMovement;

    InputAction moveAction;
    InputAction jumpAction;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        moveAction.started += OnMove;
        moveAction.canceled += OnMove;
        
        jumpAction.started += OnJump;
    }

    private void OnDisable()
    {
        moveAction.started -= OnMove;
        moveAction.canceled -= OnMove;
        
        jumpAction.started -= OnJump;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(inputMovement.x, 0, inputMovement.y);
        rb.AddForce(movement * moveForce);
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        inputMovement = ctx.ReadValue<Vector2>();
    }
    
    private void OnJump(InputAction.CallbackContext ctx)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
