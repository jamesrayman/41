using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour {

	public Vector3 returnPos;
	public float lowerLimit;
	Rigidbody rigid;

	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}

	void Update () {
		if (transform.position.y < lowerLimit) {
			transform.SetPositionAndRotation (returnPos, transform.rotation);
			rigid.velocity = new Vector3();
		}
	}
}
