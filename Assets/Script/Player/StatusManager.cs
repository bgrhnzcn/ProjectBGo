using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour, IHittable
{
    [SerializeField] private float currHealth = 100;
    [SerializeField] private float maxHealth = 100;

	private void Start()
	{
		currHealth = maxHealth;
	}
	public void TakeHit(float damage)
	{
		currHealth -= damage;
        if (currHealth <= 0)
            Die();
	}

    private void Die()
    {
        Destroy(gameObject);
    }
}
