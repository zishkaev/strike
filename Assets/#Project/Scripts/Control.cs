using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
	public SimpleTouchController moveTouchController;
	public SimpleTouchController rotTouchController;
	public Weapon weapon;

	public float speed;
	public float rotSpeed;

	private Vector3 move;
	private Vector3 rot;

	private void Start() {
		rotTouchController.TouchStateEvent += weapon.Shoot;
	}

	public void Move(Vector2 value) {
		move = new Vector3(value.x, 0, value.y);
		transform.position += move * Time.deltaTime * speed;
	}

	public void Rotate(Vector2 value) {
		//float rotY = value.x * rotSpeed * Time.deltaTime;
		Vector3 rotY = new Vector3(value.x, 0, value.y);
		transform.forward = Vector3.Lerp(transform.forward, rotY, rotSpeed * Time.deltaTime);
	}

	private void Update() {
		Move(moveTouchController.GetTouchPosition);
		Rotate(rotTouchController.GetTouchPosition);
	}

	private void OnDestroy() {
		rotTouchController.TouchStateEvent -= weapon.Shoot;
	}
}
