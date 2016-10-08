using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private static Player instance;
	public static Player Instance {
		get {
			if(instance == null) {
				instance = GameObject.FindObjectOfType<Player>();
				if(instance == null) {
					Debug.LogWarning("Nenhum Player do tipo GameManager foi encontrado");
				}
			}

			return instance;
		}
	}

	public Vector3 GetPosition() {
		return transform.position;
	}
}
