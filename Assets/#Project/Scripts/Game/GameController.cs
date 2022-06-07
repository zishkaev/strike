using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public Action 
		onStartGame, 
		onEndGame;

	private void Awake() {
		instance = this;
	}

	public void StartGame() {
		Points.ResetScore();
		onStartGame?.Invoke();
	}

	public void StopGame() {
		onEndGame?.Invoke();
		Saver.instance.AddScore(Points.score);
	}
}
