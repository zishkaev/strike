using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points {
	public static int score;
	public static Action onChangeScore;

	public static void AddScore(int value) {
		score += value;
		onChangeScore?.Invoke();
	}

	public static void ResetScore() {
		score = 0;
	}
}
