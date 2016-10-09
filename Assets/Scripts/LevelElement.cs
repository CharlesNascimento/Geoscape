using UnityEngine;
using System.Collections;

public class LevelElement : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.CompareTag("Player")) {
			LeanTween.cancel(coll.gameObject);
		}
	}
}
