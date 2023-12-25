using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	[Header("Shooting")]
	[SerializeField] private GameObject projectile;
	[SerializeField] private float projSpeed;
	private Vector3 dir;

	void Update()
    {
		Aim();
		Shoot();
    }
	private void Shoot()
	{
		GameObject bulletInstance;
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			float angle = Mathf.Atan2(dir.y, dir.x);
			bulletInstance = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, (Mathf.Rad2Deg * angle) - 90));
			bulletInstance.GetComponent<Rigidbody2D>().velocity = dir * projSpeed;
			Destroy(bulletInstance, 2f);
		}
	}
	private void Aim()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		dir = ((Vector2)(mousePos - transform.position)).normalized;
		Debug.DrawLine(transform.position, transform.position + dir);
	}
}
