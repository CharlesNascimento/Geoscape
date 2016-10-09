using UnityEngine;
using System.Collections;

public class MagneticElement : MonoBehaviour {

	private Player player;
	public LTDescr tween;

	public float force;

	void Awake() {
		player = Player.Instance;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.CompareTag("Player")) {
			LeanTween.move(other.gameObject, this.transform.position, 0.3f);
			// other.GetComponent<Rigidbody2D>().AddForce(-(player.GetPosition() - this.transform.position).normalized * force, ForceMode2D.Impulse);
		}
	}

	public void OnComplete() {
		Debug.Log("fnaowfnaow"); 
	}

}
