using UnityEngine;
using System.Collections;

public class GlueElement : MonoBehaviour {

	public Transform elementsLevel;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Glue(coll.transform);

		IEnumerator coroutine = UnGlue(coll.transform, 1f);
		StartCoroutine(coroutine);
	}

	private void Glue(Transform playerTransform) {
		playerTransform.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		playerTransform.SetParent(this.transform);
	}

	private IEnumerator UnGlue(Transform playerTransform, float timeToWait) {

		yield return new WaitForSeconds(timeToWait);

		playerTransform.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
		playerTransform.SetParent(null);
	}
}
