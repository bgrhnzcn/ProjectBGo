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
    [SerializeField] private AnimatorController an;
    [SerializeField] private float speed;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
        }
    }
}
