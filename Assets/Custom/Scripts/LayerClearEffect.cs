using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for the effect of clearing a layer

public class LayerClearEffect : MonoBehaviour {

	public static LayerClearEffect main;
	public Color[] colors;
	public int particleBundleSize;
	public float dropSpeed;

	ParticleSystem emitter;
	Dictionary<GameObject, float> dropQueue;

	void Start () {
		main = this;
		dropQueue = new Dictionary<GameObject, float> ();
		emitter = GetComponent<ParticleSystem>();
	}

	void Update () {
		Dictionary<GameObject, float> modifiedDropQueue = new Dictionary<GameObject, float>(dropQueue);

		foreach (GameObject block in dropQueue.Keys) {
			float distLeft = dropQueue [block];

			if (block == null || distLeft <= 0) {
				modifiedDropQueue.Remove (block);
				continue;
			}

			float dropDistance = Mathf.Min (dropSpeed * Time.deltaTime, distLeft);

			block.transform.position += dropDistance * Vector3.down;
			modifiedDropQueue [block] = distLeft - dropDistance;
		}
		dropQueue = modifiedDropQueue;
	}

	public void Emit (Vector3 position) {
		transform.position = position;
		emitter.Emit (particleBundleSize);
	}

	public void Drop (GameObject block) {
		if (dropQueue.ContainsKey (block)) {
			dropQueue [block] += GameSettings.blockSize;
		} else {
			dropQueue.Add (block, GameSettings.blockSize);
		}
	}
}
