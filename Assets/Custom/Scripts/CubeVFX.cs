using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for the visual effects of individual cubes

public class CubeVFX : MonoBehaviour {
	List<Renderer> cubes;

	void Start () {
		cubes = new List<Renderer> ();

		for (int i = 0; i < transform.childCount; i++) {
			GameObject child = transform.GetChild (i).gameObject;
			Renderer r = child.GetComponent<Renderer> ();
			if (r != null) {
				cubes.Add(r);
			}
		}
	}

	public void ApplyColor (Color color) {
		foreach (Renderer r in cubes) {
			r.material.color = color;
		}
	}
}
