using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    [SerializeField, Min(0f)]
    private float acceleration, maxSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogWarning("Robot RigidBody2D not found"); 
    }
    public void Move(bool up, bool down, bool left, bool right)
    {
        Vector2 force = Vector2.zero;

        // Calculate the force to apply based on inputs
        if (up) force += Vector2.up;
        if (down) force += Vector2.down;
        if (left) force += Vector2.left;
        if (right) force += Vector2.right;

        // Apply force to the Rigidbody2D
        if (force != Vector2.zero)
        {
            rb.AddForce(force.normalized * acceleration);

            // Clamp velocity to max speed
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
    }
}
