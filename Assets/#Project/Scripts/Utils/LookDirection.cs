using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour {

	public Vector3 forward;

	private void Update() {
		transform.forward = forward;
	}
}
