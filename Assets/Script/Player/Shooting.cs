using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Shooting : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private GameObject projectile;
    private Vector3 dir;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		Aim();
		Shoot();
	}

	private void Shoot()
	{
		GameObject bulletObject;
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			bulletObject = Instantiate(projectile, transform.position, transform.rotation);
			bulletObject.GetComponent<Rigidbody2D>().velocity = dir * speed;
			Destroy(bulletObject, 5f);
		}
		Quaternion.LookRotation(transform.up, dir);
	}

	private void Aim()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		dir = ((Vector2)(mousePos - transform.position)).normalized;
		Debug.DrawLine(transform.position, transform.position + dir);
	}
}
