using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	[SerializeField] private WeaponType type;
	[SerializeField] private PoolItem projectile;
	[SerializeField] protected Transform muzzle;
	[SerializeField] protected Owner owner;
	[SerializeField] private float rateOfFire;
	protected Pool pool;
	private bool isShoot;
	private float delayShoot;
	private float t;

	public string WeaponName => type.ToString();

	protected virtual void Start() {
		delayShoot = 60f / rateOfFire;
		if (!pool) {
			pool = Pool.NewPool(projectile);
		}
	}

	public void Shoot(bool state) {
		isShoot = state;
	}

	public virtual void Shoot() {
		PoolItem item = pool.GetItem();
		item.transform.position = muzzle.position;
		item.transform.forward = muzzle.forward;
		item.GetComponent<Projectile>().SetOwner(owner);
		item.gameObject.SetActive(true);
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