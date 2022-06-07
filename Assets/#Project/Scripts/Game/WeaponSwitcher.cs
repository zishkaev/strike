using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {
	[SerializeField] private Weapon[] weapons;
	[SerializeField] private Control control;
	[SerializeField] private MenuController menuUI;
	private int curWeaponId = 0;

	public Action<Weapon> onChangeWeapon;

	private void Start() {
		for(int i = 0; i < weapons.Length; i++) {
			weapons[i].gameObject.SetActive(false);
		}
		weapons[curWeaponId].gameObject.SetActive(true);

		control.onTouchRightControl += Shoot;
		menuUI.onChangeWeapon += ChangeWeapon;
	}

	private void ChangeWeapon() {
		weapons[curWeaponId].gameObject.SetActive(false);
		curWeaponId++;
		if (curWeaponId >= weapons.Length)
			curWeaponId = 0;
		weapons[curWeaponId].gameObject.SetActive(true);
		onChangeWeapon?.Invoke(weapons[curWeaponId]);
	}

	private void Shoot(bool value) {
		weapons[curWeaponId].Shoot(value);
	}

	private void OnDestroy() {
		control.onTouchRightControl -= Shoot;
		menuUI.onChangeWeapon -= ChangeWeapon;
	}
}
