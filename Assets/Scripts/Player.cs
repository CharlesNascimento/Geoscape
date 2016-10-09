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

	void Update() {
		if(Input.GetKeyDown(KeyCode.Return)) {
			transform.GetComponent<Rigidbody2D>().AddForce(DegreeToVector2(45) * 10, ForceMode2D.Impulse);
		}
	}

	public static Vector2 RadianToVector2(float radian) {
    	return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
 	}
  
 	public static Vector2 DegreeToVector2(float degree) {
    	return RadianToVector2(degree * Mathf.Deg2Rad);
 	}

	public Vector3 GetPosition() {
		return transform.position;
	}
}
