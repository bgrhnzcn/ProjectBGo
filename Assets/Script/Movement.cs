using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private bool isGrounded;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpHigh;
    [SerializeField] private Collider2D groundChecker;
   
    private Rigidbody2D rigidBody2D;
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>(); 
    }
    void Update()
    {
        Move();
    }
    
    private void Move()
    {
        if(Input.GetKey(KeyCode.D) && rigidBody2D.velocity.x < maxSpeed)
            rigidBody2D.AddForce(Vector2.right * acceleration);

        if(Input.GetKey(KeyCode.A) && rigidBody2D.velocity.x > -maxSpeed)
            rigidBody2D.AddForce(Vector2.left * acceleration);

        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rigidBody2D.AddForce(Vector2.up * jumpHigh);
            isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = true;
	}
}
