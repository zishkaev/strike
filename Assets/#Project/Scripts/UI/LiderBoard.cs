using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiderBoard : MonoBehaviour {
	[SerializeField] private Text[] texts;

	private void Start() {
		UpdateLiderBoard();
		Saver.instance.onAddScore += UpdateLiderBoard;
	}

	private void UpdateLiderBoard() {
		for (int i = 0; i < Saver.instance.Scores.Length; i++) {
			if (Saver.instance.Scores[i] == 0)
				texts[i].text = "";
			else
				texts[i].text = Saver.instance.Scores[i].ToString();
		}
	}

	private void OnDestroy() {
		Saver.instance.onAddScore -= UpdateLiderBoard;
	}
}