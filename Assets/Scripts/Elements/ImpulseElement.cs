using UnityEngine;
using System.Collections;

public class ImpulseElement : MonoBehaviour {

	public float force;

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.CompareTag("Player")) {
			coll.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
		}
	}

}
