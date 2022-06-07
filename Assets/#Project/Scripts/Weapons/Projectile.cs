using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour {
	[SerializeField] private float moveSpeed;
	[SerializeField] private float radius;
	[SerializeField] private float damage;
	[SerializeField] private float lifeTime;
	public UnityEvent onDamage;
	private Owner owner;
	private RaycastHit raycastHit;

	private void Start() {
		Invoke(nameof(DestroyProjectile), lifeTime);
	}

	public void SetOwner(Owner owner) {
		this.owner = owner;
	}

	public void Check(Collider collider) {
		Owner checkOwner = collider.GetComponentInParent<Owner>();
		if (checkOwner && checkOwner.teamType != owner.teamType) {
			checkOwner.health.Damage(damage);
			DestroyProjectile();
		}
	}

	public void Update() {
		if (Physics.SphereCast(transform.position, radius, transform.forward, out raycastHit, moveSpeed * Time.deltaTime)) {
			Check(raycastHit.collider);
		}
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}

	private void DestroyProjectile() {
		onDamage?.Invoke();
	}
}
