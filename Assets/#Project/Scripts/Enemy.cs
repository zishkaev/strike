using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	[SerializeField] private NavMeshAgent navMeshAgent;

	private Transform player;

	private void Start() {
		player = Player.instance.transform;
	}

	private void Update() {
		navMeshAgent.SetDestination(player.position);
	}
}
