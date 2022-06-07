using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {
	[SerializeField] private float shootSpread;
	[SerializeField] private int bulletSheels;
	private float delayAngle;
	private float halfSpread;

	protected override void Start() {
		base.Start();
		delayAngle = shootSpread / bulletSheels;
		halfSpread = shootSpread / 2f;
	}

	public override void Shoot() {
		PoolItem item;
		for (int i = 0; i < bulletSheels; i++) {
			item = pool.GetItem();
			item.transform.position = muzzle.position;
			item.transform.forward = muzzle.forward;
			item.transform.rotation = Quaternion.AngleAxis(halfSpread - delayAngle * i, Vector3.up) * item.transform.rotation;
			item.GetComponent<Projectile>().SetOwner(owner);
			item.gameObject.SetActive(true);
		}
	}
}
