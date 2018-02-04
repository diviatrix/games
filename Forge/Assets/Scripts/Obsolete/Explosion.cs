using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	public int damage;
	public float lifetime;
	public List<GameObject> targetlist;
	void Start(){
		Destroy(gameObject,lifetime);
	}
	void OnTriggerEnter(Collider col)
	{
		if(targetlist.Find(GameObject => GameObject == col.gameObject)){
			return;
		}
		targetlist.Add(col.gameObject);
		var hit = col.gameObject;
		var rigid = col.GetComponent<Rigidbody>();

		var health = hit.GetComponent<Health>();

		if (health != null)
		{
			health.TakeDamage(damage);
		}
		if (rigid != null){
			rigid.AddForce(new Vector3(Random.Range(-10,10),Random.Range(1,10),Random.Range(-10,10))*damage/2,ForceMode.Impulse);
		}
	}
}
