using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollower : MonoBehaviour
{
	public Transform target;
	public float speed;
	public bool useOffset;

	private Vector3 offset;

	private void Start() {
		offset = Vector3.zero;
		if (useOffset) {
			offset = transform.position - target.position;
		}
	}

	void Update() {
		transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
	}
}
