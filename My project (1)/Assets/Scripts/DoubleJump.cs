using UnityEditor.Callbacks;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundCheckRadius = 1f;
    public int jumpCount = 0;
    public int maxJumps = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        // check if the character is currently on the ground
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
        if (isGrounded)
        {
            jumpCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {   
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }
}
