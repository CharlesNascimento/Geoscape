using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum GameplayProtoype {
	PlayerControlled,
	AutoControlled
}

public class GameManager : MonoBehaviour {

	private bool isGameOver = false;
	private bool isLevelCompleted = false;

	public GameplayProtoype gameplayProtoype;

	private static GameManager instance;
	public static GameManager Instance {
		get {
			if(instance == null) {
				instance = GameObject.FindObjectOfType<GameManager>();
				if(instance == null) {
					Debug.LogWarning("Nenhum GameObject do tipo GameManager foi encontrado");
				}
			}

			return instance;
		}
	}

	void Awake () {
		instance = this;
	}

	void Start() {
		StartGame();
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Return)) {
			LevelCompleted();
		}
	}
	
	public void StartGame() {
		if(gameplayProtoype == GameplayProtoype.PlayerControlled) {
			// Liberar os controles do jogador
		} else if(gameplayProtoype == GameplayProtoype.AutoControlled) {
			// Inicia a movimentação do personagem
		}
	}

	public GameObject luz;
	public void LevelCompleted() {
		isLevelCompleted = true;
		luz.SetActive(false);
		// Player.Instance.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		CharacterControl.instance.SetMovementBlocked(true);
		GameObject[] levelElements = GameObject.FindGameObjectsWithTag("LevelElement");
		for(int i = 0; i < levelElements.Length; i++) {
			BlockMover[] bm = levelElements[i].GetComponents<BlockMover>();
			if(bm != null) {
				for(int j = 0; j < bm.Length; j++) {
					bm[j].blockTriggered = false;
				}
			}
			levelElements[i].AddComponent<Rigidbody2D>();
		}
		AudioManager.instance.PlayAudio(Audios.Win);
		Debug.Log("Level Completed!!");
	}

	public bool IsLevelCompleted() {
		return isLevelCompleted;
	}

	public bool GameOver() {
		if(isLevelCompleted) {
			SceneManager.LoadScene("Level01");
			return false;
		}

		AudioManager.instance.PlayAudio(Audios.Died);
		isGameOver = true;
		SceneManager.LoadScene("Level01");
		Debug.Log("Dead!!");

		return true;
	}

	public bool IsGameOver() {
		return isGameOver;
	}
}
