using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float rate;

	void Update () {
		transform.Rotate (0, 0, rate * Time.deltaTime);
	}
}
