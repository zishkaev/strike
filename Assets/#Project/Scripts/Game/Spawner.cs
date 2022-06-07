using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour {
	[SerializeField] private Pool[] enemyPools;
	[SerializeField] private float delaySpawn;
	private Transform playerPos;
	private float radius;
	private float t = 0f;

	private void Start() {
		playerPos = Player.instance.transform;
		CalcRadius();
		GameController.instance.onStartGame += StartSpawn;
		GameController.instance.onEndGame += StopSpawn;
		StopSpawn();
	}

	private void StartSpawn() {
		enabled = true;
	}

	private void StopSpawn() {
		enabled = false;
	}

	private void CalcRadius() {
		Ray ray0 = Camera.main.ViewportPointToRay(new Vector2(0, 0));
		RaycastHit hit0;
		Physics.Raycast(ray0, out hit0, 100);
		radius = hit0.point.magnitude;
	}

	private void Update() {
		if (t > delaySpawn) {
			SpawnEnemy();
			t = 0;
		}
		t += Time.deltaTime;
	}

	private void SpawnEnemy() {
		PoolItem poolItem = enemyPools[Random.Range(0, enemyPools.Length)].GetItem();
		poolItem.transform.position = GetSpawnPoint();
		poolItem.transform.rotation = Quaternion.identity;
		poolItem.gameObject.SetActive(true);
	}

	private Vector3 GetSpawnPoint() {
		float angle = Random.Range(0, 360);
		float rad = angle * Mathf.PI / 180f;
		Vector3 point = new Vector3(radius * Mathf.Sin(rad), 0, radius * Mathf.Cos(rad));
		NavMeshHit hit;
		if (!NavMesh.SamplePosition(playerPos.position + point, out hit, 1.0f, NavMesh.AllAreas)) {
			return GetSpawnPoint();
		} else {
			return playerPos.position + point;
		}
	}

	private void OnDestroy() {
		GameController.instance.onStartGame -= StartSpawn;
		GameController.instance.onEndGame -= StopSpawn;
	}
}
