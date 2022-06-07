using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {
	public Transform target;
	public bool useOffset;

	private Vector3 offset;

	private void Start() {
		offset = Vector3.zero;
		if (useOffset) {
			offset = transform.position - target.position;
		}
	}

	void Update() {
		transform.position = target.position + offset;
	}
}
