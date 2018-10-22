using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A visual representation of BlockArea.occupied
// Has no dependents

public class GameAreaDebug : MonoBehaviour {

	public GameObject cube;
	public static GameAreaDebug main;

	GameObject[,,] arr;

	void Start () {
		main = this;
		arr = new GameObject[GameSettings.areaSize, GameSettings.fullAreaHeight, GameSettings.areaSize];

		for (int i = 0; i < GameSettings.areaSize; i++) {
			for (int j = 0; j < GameSettings.areaSize; j++) {
				for (int k = 0; k < GameSettings.fullAreaHeight; k++) {
					GameObject g = Instantiate<GameObject> (cube);
					g.transform.localScale = Vector3.one * GameSettings.blockSize;
					g.transform.localPosition =
						new Vector3(transform.position.x + i*GameSettings.blockSize,
									transform.position.y + k*GameSettings.blockSize,
									transform.position.z + j*GameSettings.blockSize);
					g.SetActive (false);
					arr [i, k, j] = g;
					g.transform.parent = transform;
				}
			}
		}
	}

	void Update () {
		Rebuild ();
	}

	public void Rebuild () {
		for (int i = 0; i < GameSettings.areaSize; i++) {
			for (int j = 0; j < GameSettings.areaSize; j++) {
				for (int k = 0; k < GameSettings.fullAreaHeight; k++) {
					arr [i, k, j].SetActive (BlockArea.occupied [i, k, j].OccupiedByBlock());
				}
			}
		}
	}
}
