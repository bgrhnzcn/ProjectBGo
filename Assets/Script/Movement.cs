using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;


public class Movement : MonoBehaviour
{
    private bool isGrounded;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpHigh;
   
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

        if(Input.GetKeyDown(KeyCode.W))
            rigidBody2D.AddForce(Vector2.up * jumpHigh);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
