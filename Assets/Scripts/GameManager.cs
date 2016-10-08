using UnityEngine;
using System.Collections;

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
	
	public void StartGame() {
		if(gameplayProtoype == GameplayProtoype.PlayerControlled) {
			// Liberar os controles do jogador
		} else if(gameplayProtoype == GameplayProtoype.AutoControlled) {
			// Inicia a movimentação do personagem
		}
	}

	public void LevelCompleted() {
		isLevelCompleted = true;
		Debug.Log("Level Completed!!");
	}

	public bool IsLevelCompleted() {
		return isLevelCompleted;
	}

	public bool GameOver() {
		if(isLevelCompleted) return false;

		isGameOver = true;
		Debug.Log("Dead!!");

		return true;
	}

	public bool IsGameOver() {
		return isGameOver;
	}
}
