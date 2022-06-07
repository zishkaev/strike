using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	[SerializeField] private Owner owner;
	[SerializeField] private NavMeshAgent navMeshAgent;
	[SerializeField] private float attackDist;
	[SerializeField] private float damage;
	[SerializeField] private float timeAttackReset;
	private Transform playerPos;
	private Owner playerOwner;
	private float t;

	private void Start() {
		owner.health.onDead.AddListener(AddScore);
		playerOwner = Player.instance.Owner;
		playerPos = Player.instance.transform;
	}

	private void Update() {
		if (Vector3.Distance(transform.position, playerPos.position) < attackDist) {
			navMeshAgent.isStopped = true;
			if (t > timeAttackReset) {
				Attack();
				t = 0;
			}
		} else {
			navMeshAgent.isStopped = false;
			navMeshAgent.SetDestination(playerOwner.transform.position);
		}
		t += Time.deltaTime;
	}

	private void Attack() {
		playerOwner.health.Damage(damage);
	}

	private void AddScore() {
		Points.AddScore(1);
	}

	private void OnDestroy() {
		owner.health.onDead.RemoveListener(AddScore);
	}
}
