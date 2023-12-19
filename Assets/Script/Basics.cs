using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject circle;
    private Rigidbody2D circleR;
    private Transform circleT;

    void Start()
    {
        circleR = circle.GetComponent<Rigidbody2D>();
        circleT = circle.transform;
    }

    void Update()
    {
        Debug.Log("deneme");
    }
}

