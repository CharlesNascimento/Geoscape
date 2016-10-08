using UnityEngine;
using System.Collections;

public class DeathBarrier : MonoBehaviour {

	private GameManager gameManager;

	void Awake() {
		gameManager = GameManager.Instance;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.CompareTag("Player")) {
			gameManager.GameOver();
		}
	}
}
