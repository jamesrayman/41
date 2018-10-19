using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gs = GameSettings;

// responsible for non-functional elements of the block area

public class BlockAreaCosmetics : MonoBehaviour {

	public GameObject floorBlock;
	public GameObject borderBlock;

	public void Start() {
		floorBlock.transform.localScale = gs.blockSize * Vector3.one;

		float start = -(gs.areaSize - 1) * gs.blockSize / 2;

		/*for (int i = 0; i < areaSize; i++) {
			for (int j = 0; j < areaSize; j++) {
				GameObject g = Instantiate<GameObject> (floorBlock);
				g.transform.localPosition = new Vector3(start + i*blockSize, floorHeight, start + j*blockSize);
			}
		}*/

		GameObject leftBorder = Instantiate<GameObject> (borderBlock);
		GameObject rightBorder = Instantiate<GameObject> (borderBlock);
		GameObject upperBorder = Instantiate<GameObject> (borderBlock);
		GameObject lowerBorder = Instantiate<GameObject> (borderBlock);

		leftBorder.transform.localScale = new Vector3 (gs.borderWidth, gs.borderHeight, gs.areaSize*gs.blockSize);
		rightBorder.transform.localScale = new Vector3 (gs.borderWidth, gs.borderHeight, gs.areaSize*gs.blockSize);
		upperBorder.transform.localScale = new Vector3 (gs.areaSize*gs.blockSize+2*gs.borderWidth, gs.borderHeight, gs.borderWidth);
		lowerBorder.transform.localScale = new Vector3 (gs.areaSize*gs.blockSize+2*gs.borderWidth, gs.borderHeight, gs.borderWidth);

		leftBorder.transform.localPosition = new Vector3 (start-gs.blockSize/2-gs.borderWidth/2, 0.5f, 0);
		rightBorder.transform.localPosition = new Vector3 (-(start-gs.blockSize/2-gs.borderWidth/2), 0.5f, 0);
		upperBorder.transform.localPosition = new Vector3 (0, 0.5f, start-gs.blockSize/2-gs.borderWidth/2);
		lowerBorder.transform.localPosition = new Vector3 (0, 0.5f, -(start-gs.blockSize/2-gs.borderWidth/2));
	}
}
