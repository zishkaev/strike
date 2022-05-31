using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float maxHealth;

	private float health;

	private void Start() {
		health = maxHealth;
	}

	public void Damage(float damage) {
		health -= damage;
		if (health <= 0) {
			health = 0;
			Dead();
		}
	}

	public void Dead() {
		Destroy(gameObject);
	}
}
