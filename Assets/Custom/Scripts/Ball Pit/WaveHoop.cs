using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHoop : MonoBehaviour {

	public float period;
	public float amplitude;
	public float shift;

	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y, amplitude * Mathf.Sin ((2*Mathf.PI / period)*(Time.time - shift)));
	}
}
