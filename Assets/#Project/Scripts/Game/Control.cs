using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
	[SerializeField] private SimpleTouchController moveTouchController;
	[SerializeField] private SimpleTouchController rotTouchController;

	[SerializeField] private float speed;
	[SerializeField] private float rotSpeed;

	private Vector3 move;

	public Action<bool> onTouchRightControl;

	private void Start() {
		rotTouchController.TouchStateEvent += Shoot;
	}

	public void Shoot(bool state) {
		onTouchRightControl?.Invoke(state);
	}

	private void Update() {
		Move(moveTouchController.GetTouchPosition);
		Rotate(rotTouchController.GetTouchPosition);
	}
	public void Move(Vector2 value) {
		move = new Vector3(value.x, 0, value.y);
		transform.position += move * Time.deltaTime * speed;
	}

	public void Rotate(Vector2 value) {
		Vector3 rotY = new Vector3(value.x, 0, value.y);
		transform.forward = Vector3.Lerp(transform.forward, rotY, rotSpeed * Time.deltaTime);
	}

	private void OnDestroy() {
		rotTouchController.TouchStateEvent -= Shoot;
	}
}
