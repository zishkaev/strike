using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] private Owner owner;

	public Owner Owner => owner;
	public static Player instance;

	private void Awake() {
		instance = this;
	}

	private void Start() {
		owner.health.onDead.AddListener(EndGame);
		GameController.instance.onStartGame += ResetData;
	}

	public void EndGame() {
		GameController.instance.StopGame();
	}

	private void ResetData() {
		owner.health.ResetHealth();
	}

	private void OnDestroy() {
		owner.health.onDead.RemoveListener(EndGame);
		GameController.instance.onStartGame -= ResetData;
	}
}
