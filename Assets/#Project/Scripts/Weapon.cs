using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	[SerializeField] private Projectile projectile;
	[SerializeField] private Transform muzzle;
	[SerializeField] private Owner owner;
	[SerializeField] private float rateOfFire;
	private bool isShoot;
	private float delayShoot;
	private float t;


	private void Start() {
		delayShoot = 60f / rateOfFire;
	}

	public void Shoot(bool state) {
		isShoot = state;
	}

	public void Shoot() {
		Projectile bullet = Instantiate(projectile, muzzle.position, Quaternion.identity);
		bullet.transform.forward = muzzle.forward;
		bullet.SetOwner(owner);
	}

	private void Update() {
		if (isShoot) {
			if (t > delayShoot) {
				Shoot();
				t = 0;
			}
			t += Time.deltaTime;
		}
	}
}
