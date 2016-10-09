using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	//public bool destroySelfOnImpact = false;
	//public float delayBeforeDestroy = 0.0f;
	public GameObject explosionPrefab;

	void OnTriggerEnter(Collider collision) {

		Debug.Log("Sucesso");

		if (explosionPrefab != null) {
			Instantiate (explosionPrefab, transform.position, transform.rotation);
		}

		GameManager.Instance.GameOver();


	}


}
