using UnityEngine;
using System.Collections;

public class ImpulseElement : MonoBehaviour {

	public float angle;

	public float force;

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.CompareTag("Player")) {
			coll.transform.GetComponent<Rigidbody2D>().AddForce(DegreeToVector2(angle) * force, ForceMode2D.Impulse);
		}
	}

	public static Vector2 RadianToVector2(float radian) {
    	return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
 	}
  
 	public static Vector2 DegreeToVector2(float degree) {
    	return RadianToVector2(degree * Mathf.Deg2Rad);
 	}
}
