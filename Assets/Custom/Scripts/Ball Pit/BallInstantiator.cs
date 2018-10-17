using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInstantiator : MonoBehaviour {
	public GameObject ball;
	public Material [] materials;
	public float spacing;
	public float randomError;
	public int len;
	public int nLayers;
	public float yStart;
	public float yDelta;

	void Start () {
		for (int layer = 0; layer < nLayers; layer++) {
			for (int x = 0; x < len; x++) {
				for (int z = 0; z < len; z++) {
					GameObject g = Instantiate (ball);
					ball.GetComponent<MeshRenderer> ().material = materials[(int)(materials.Length * Random.value)];
					g.transform.SetPositionAndRotation (
						new Vector3 (x * spacing - (len * spacing) / 2 + randomError * Random.value, yStart + layer * yDelta, 
							z * spacing - (len * spacing) / 2 + randomError * Random.value),
						g.transform.rotation);
				}
			}
		}
	}
}
