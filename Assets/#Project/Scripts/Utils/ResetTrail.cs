using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrail : MonoBehaviour {
	[SerializeField] private TrailRenderer trail;

	private void OnEnable() {
		for (int i = 0; i < trail.positionCount; i++) {
			trail.SetPosition(i, transform.position);
		}
	}
}
