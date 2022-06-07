using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
	[SerializeField] private Text text;

	private void Start() {
		Points.onChangeScore += UpdateUI;
	}

	public void UpdateUI() {
		text.text = Points.score.ToString();
	}
	private void OnDestroy() {
		Points.onChangeScore -= UpdateUI;
	}
}
