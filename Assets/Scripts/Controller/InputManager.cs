using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public float speed;

	void Start () {
	
	}
	
	void Update () {
		this.transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * speed);
	}
}
