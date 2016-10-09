using UnityEngine;
using System.Collections;

public class GlueElement : MonoBehaviour {

	private bool isGlued = false;

	void OnCollisionEnter2D(Collision2D coll) {
		if(isGlued) return;
		Glue(coll.transform);

		IEnumerator coroutine = UnGlue(coll.transform, 1f);
		StartCoroutine(coroutine);
	}

	void OnCollisionExit2D(Collision2D coll) {
		isGlued = false;
	}

	private void Glue(Transform playerTransform) {
		playerTransform.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		playerTransform.SetParent(this.transform);
		CharacterControl.instance.SetMovementBlocked(true);
		isGlued = true;
	}

	private IEnumerator UnGlue(Transform playerTransform, float timeToWait) {

		yield return new WaitForSeconds(timeToWait);

		playerTransform.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
		CharacterControl.instance.SetMovementBlocked(false);
		playerTransform.SetParent(null);
		isGlued = false;
	}
}
