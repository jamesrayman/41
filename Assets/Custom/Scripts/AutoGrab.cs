using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using gs = GameSettings;

// Responsible for auto grab feature

public class AutoGrab : MonoBehaviour {
	VRTK_InteractGrab interactGrab;
	VRTK_InteractTouch interactTouch;

	void Start () {
		interactGrab = GetComponent<VRTK_InteractGrab> ();
		interactTouch = GetComponent<VRTK_InteractTouch> ();
	}

	public void TryAutoGrab () {
		if (gs.autoGrab) {
			//StartCoroutine ("TrueTryAutoGrab");

			if (interactTouch.GetTouchedObject () == null) {
				Block block = BlockManager.AutoGrabBlock ();
				block.transform.SetPositionAndRotation (transform.position, transform.rotation);
				interactTouch.ForceTouch (block.gameObject);

				interactGrab.AttemptGrab ();
			}
		}
	}

	/* IEnumerator TrueTryAutoGrab () {
		yield return new WaitForEndOfFrame ();

		if (interactGrab.GetGrabbedObject () == null) {
			Block block = BlockManager.AutoGrabBlock ();
			block.transform.SetPositionAndRotation (transform.position, transform.rotation);

			yield return new WaitForEndOfFrame ();

			interactGrab.AttemptGrab ();
		}
	} */
}
