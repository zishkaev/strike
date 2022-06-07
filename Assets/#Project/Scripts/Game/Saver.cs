using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
	[SerializeField] private int maxSavePlayer;
	private string saveKey = "save";
	private SaveData saveData;

	public Action onAddScore;

	public static Saver instance;
	public int[] Scores => saveData.scores;


	private void Awake() {
		instance = this;
	}

	private void Start() {
		LoadSave();
	}

	private void LoadSave() {
		string stringData = PlayerPrefs.GetString(saveKey, "");
		if (string.IsNullOrEmpty(stringData)) {
			NewSaveData();
		} else {
			saveData = JsonUtility.FromJson<SaveData>(stringData);
		}
	}

	private void NewSaveData() {
		saveData = new SaveData();
		saveData.scores = new int[maxSavePlayer];
	}

	private void Save() {
		string stringData = JsonUtility.ToJson(saveData);
		PlayerPrefs.SetString(saveKey, stringData);
	}

	public void AddScore(int value) {
		for (int i = 0; i < saveData.scores.Length; i++) {
			if (value > saveData.scores[i]) {
				int temp = saveData.scores[i];
				saveData.scores[i] = value;
				value = temp;
			}
		}
		Save();
		onAddScore?.Invoke();
	}
}

public class SaveData {
	public int[] scores;
}
