using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurWeaponUI : MonoBehaviour {
	[SerializeField] private WeaponSwitcher weaponSwitcher;
	[SerializeField] private Text text;

	private void Start() {
		weaponSwitcher.onChangeWeapon += UpdadeUI;
	}

	private void UpdadeUI(Weapon weapon) {
		text.text = weapon.WeaponName;
	}

	private void OnDestroy() {
		weaponSwitcher.onChangeWeapon -= UpdadeUI;
	}
}
