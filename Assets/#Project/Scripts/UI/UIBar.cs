using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBar : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private Component IBarComponent;

	private IBar bar;

	private void Start() {
		bar = IBarComponent.GetComponent<IBar>();
		bar.OnChangeValue += UpdateText;
		UpdateText();
	}

	public void UpdateText() {
		textMeshPro.text = bar.BarValue().ToString();
	}
}
