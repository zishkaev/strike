using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IBar {

	public float maxHealth;
	public UnityEvent onDead;
	private float health;

	public float CurHealth {
		get {
			return health;
		}
		set {
			health = value;
			OnChangeValue?.Invoke();
		}
	}


	public Action OnChangeValue { get; set; }

	public void OnEnable() {
		ResetHealth();
	}

	public void ResetHealth() {
		CurHealth = maxHealth;
	}

	public void Damage(float damage) {
		CurHealth -= damage;
		if (CurHealth <= 0) {
			CurHealth = 0;
			Dead();
		}
	}

	public void Dead() {
		onDead?.Invoke();
	}

	public float BarValue() {
		return CurHealth;
	}
}
