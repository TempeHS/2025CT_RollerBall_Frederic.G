using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce = 30; // Adjust to control bounce height

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            // Reset downward velocity for consistent bounce
            Vector3 velocity = rb.velocity;
            velocity.y = Mathf.Max(0, velocity.y);

            // Apply bounce force
            rb.velocity = velocity + Vector3.up * bounceForce;
        }
    }
}
