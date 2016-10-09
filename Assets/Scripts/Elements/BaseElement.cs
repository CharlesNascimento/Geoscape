using UnityEngine;
using System.Collections;

public class BaseElement : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.CompareTag("Player")) {
			AudioManager.instance.PlayAudio(Audios.Base);
		}
	}
}
