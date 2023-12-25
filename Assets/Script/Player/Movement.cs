using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpHigh;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooldown;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isJumped;
    [SerializeField] private bool isNotDoubleJumped;
    [SerializeField] private bool isDashing;
    private float horizontalAxis;
	private Rigidbody2D rb;
	private Vector3 prevPos;
    private bool canDash;

	void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        prevPos = transform.position;
	}
	void Update()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        Walk(horizontalAxis);
		if (Input.GetKeyDown(KeyCode.W))
            Jump();
		if (Input.GetKeyDown(KeyCode.LeftShift))
			Dash();
		Debug.DrawLine(transform.position, prevPos, Color.cyan, 2);
        prevPos = transform.position;
    }

	private void Jump()
	{
		if (isGrounded || isNotDoubleJumped)
		{
			if (!isNotDoubleJumped)
				return;
			if (!isGrounded)
				isNotDoubleJumped = false;
			rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += new Vector2(horizontalAxis, 1 * jumpHigh);
			isGrounded = false;
		}
	}

	private void Dash()
    {
        if (isDashing)
            return;
        canDash = false;
        rb.excludeLayers = enemyMask;
	}

	private void Walk(float horizontalAxis)
    {
        rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(horizontalAxis * maxSpeed, 0), Time.deltaTime * acceleration);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = true;
        isNotDoubleJumped = true;
	}
}
