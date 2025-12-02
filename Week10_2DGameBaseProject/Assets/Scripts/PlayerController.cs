using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public float JumpForce = 5f;
    
    private Rigidbody2D _rigidbody2D;
    private float _moveX;
    private bool _isGrounded;
    private bool _jumpPressed;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_rigidbody2D == null)
        {
            Debug.LogError("No Rigidbody2D found!", gameObject);
        }
    }

    // Update: Called every frame (varies with frame rate: 30fps, 60fps, 120fps, etc.)
    // Use for: Input detection, UI updates, non-physics calculations
    private void Update()
    {
        _moveX = 0;
        
        // Left arrow or A key
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _moveX = -1;
        }
        // Right arrow or D key
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _moveX = 1;
        }
        
        // Jump with Space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpPressed = true;
        }
    }
    
    // FixedUpdate: Called at a fixed time interval (default: 0.02 seconds = 50 times per second)
    // Use for: Physics calculations, Rigidbody movement
    // Why? Physics engine also runs at fixed intervals, so timing matches perfectly
    private void FixedUpdate()
    {
        // Apply physics movement here for smooth and consistent motion
        _rigidbody2D.linearVelocity = new Vector2(_moveX * MoveSpeed, _rigidbody2D.linearVelocity.y);

        if (_jumpPressed && _isGrounded)
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, JumpForce);
            _jumpPressed = false;
        }
    }
    
    // Check if player is touching the ground
    // OnCollisionStay2D: Called every frame while colliding with another collider
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if colliding object has "Ground" tag
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
    
    // OnCollisionExit2D: Called when player stops touching the ground
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}