using UnityEngine;
using System.Collections;

public class LevelCompleted : MonoBehaviour {

	private GameManager gameManager;

	void Awake() {
		gameManager = GameManager.Instance;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.CompareTag("Player")) {
			gameManager.LevelCompleted();
		}
	}

}
