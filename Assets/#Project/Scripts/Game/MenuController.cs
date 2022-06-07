using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
	[SerializeField] private GameObject[] menuUI;
	[SerializeField] private GameObject[] gameUI;

	public Action onChangeWeapon;

	private void Start() {
		GameController.instance.onStartGame += StartGame;
		GameController.instance.onEndGame += StopGame;
		SetMenuUI(true);
	}

	public void PressStartGame() {
		GameController.instance.StartGame();
	}

	private void StartGame() {
		SetMenuUI(false);
	}

	private void StopGame() {
		SetMenuUI(true);
	}

	public void SetMenuUI(bool state) {
		for(int i = 0; i < menuUI.Length; i++) {
			menuUI[i].SetActive(state);
		}
		for(int i = 0; i < gameUI.Length; i++) {
			gameUI[i].SetActive(!state);
		}
	}

	public void ChangeWeapon() {
		onChangeWeapon?.Invoke();
	}

	private void OnDestroy() {
		GameController.instance.onStartGame -= StartGame;
		GameController.instance.onEndGame -= StopGame;
	}
}
