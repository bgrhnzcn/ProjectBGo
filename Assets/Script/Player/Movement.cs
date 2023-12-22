using System;
using UnityEditor.UIElements;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isDashNotUsed; 
    [SerializeField] private bool isNotDoubleJumped;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpHigh;
    [SerializeField] private float dashSpeed;
    private float horizontalAxis;
	private bool isJumped;
	private Rigidbody2D rigidBody2D;
	Vector3 prevPos;

	void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        prevPos = transform.position;
    }
    void FixedUpdate()
    {
        GetInput();
        Move();
        Debug.DrawLine(transform.position, prevPos, Color.cyan, 2);
        prevPos = transform.position;
    }

	private void GetInput()
	{
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        isJumped = Input.GetKeyDown(KeyCode.W);
	}

	private void Move()
    {
        if(rigidBody2D.velocity.x < maxSpeed && rigidBody2D.velocity.x > -maxSpeed)
            rigidBody2D.AddForce(Vector2.right * horizontalAxis * acceleration);

        if(Input.GetKeyDown(KeyCode.E) && isDashNotUsed)
            rigidBody2D.AddForce(Vector2.right * dashSpeed);

        if(isJumped && (isGrounded || isNotDoubleJumped))
        {
            if(!isNotDoubleJumped)
                return;
            if(!isGrounded)
                isNotDoubleJumped = false;
            rigidBody2D.AddForce(Vector2.up * jumpHigh);
            isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = true;
        isNotDoubleJumped = true;
        isDashNotUsed = true;
	}
}
