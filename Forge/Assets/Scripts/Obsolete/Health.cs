using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : MonoBehaviour {
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public RectTransform healthBar;

	public bool destroyOnDeath;

	private NetworkStartPosition[] spawnPoints;

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if(currentHealth <= 0)
		{
			if (destroyOnDeath){
				Destroy(gameObject);
			} else {
				currentHealth = maxHealth;
			}
			
		}		
	}
	void OnChangeHealth(int currentHealth){
		if (healthBar != null)
			healthBar.sizeDelta = new Vector2(currentHealth/10, healthBar.sizeDelta.y);
	}
}
