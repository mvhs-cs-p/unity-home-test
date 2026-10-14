using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float jumpForce = 5f;
    public float walkForce = 4f;
    public float maxWalkSpeed = 10f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = getMoveInput();
        rb.AddForce(input * walkForce);
        Vector2 vel = rb.linearVelocity;
        if (vel.magnitude > maxWalkSpeed)
        {
            vel = rb.linearVelocity.normalized;
            vel *= maxWalkSpeed;
            rb.linearVelocity = vel;
        }


        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    public Vector2 getMoveInput()
    {
        Vector2 moveInput = Vector2.zero;
        if (Keyboard.current.aKey.isPressed)
        {
            moveInput.x += -1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            moveInput.x += 1;
        }

        return moveInput.normalized;
    }
}
