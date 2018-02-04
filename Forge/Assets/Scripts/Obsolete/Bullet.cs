using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed;
	public int damage;
	public GameObject explosivePrefab;
	public GameObject explosionEffect;
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "bullet")
			return;
			
		var hit = col.gameObject;
		var health = hit.GetComponent<Health>();
		if (health != null)
		{
			health.TakeDamage(damage);
		}	

		if (explosivePrefab != null)
		{
		Instantiate(explosionEffect,transform.position,Quaternion.identity);
		}
		if (explosivePrefab != null)
		{
			Instantiate(explosivePrefab,transform.position,Quaternion.identity);
		}
		Destroy(gameObject);		
	}
}
