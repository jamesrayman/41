using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour {

	Renderer render;
	public Color pulseColor;
	public float duration;

	float time = 10000000;
	Color origColor;

	void Start () {
		render = gameObject.GetComponent<Renderer> ();
		origColor = render.material.color;
	}

	void Update () {
		time += Time.deltaTime;

		if (time > duration)
			render.material.color = origColor;
		else
			render.material.color = Color.Lerp(origColor, pulseColor, 1 - Mathf.Sin(Mathf.PI / 2 / duration * time));
	}

	public void pulse () {
		time = 0;
	}
}
