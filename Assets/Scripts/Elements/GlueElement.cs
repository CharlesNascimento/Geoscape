using UnityEngine;
using System.Collections;

public class GlueElement : MonoBehaviour {

	private bool isGlued = true;
	private bool isOut = true;

	public float angle;
	public float force;

	void OnCollisionEnter2D(Collision2D coll) {
		Glue(coll.transform);

		IEnumerator coroutine = UnGlue(coll.transform, 1f);
		StartCoroutine(coroutine);
	}

	private void Glue(Transform playerTransform) {
		playerTransform.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		playerTransform.SetParent(this.transform);
		CharacterControl.instance.SetMovementBlocked(true);

		AudioManager.instance.PlayAudio(Audios.Slime);
	}

	private IEnumerator UnGlue(Transform playerTransform, float timeToWait) {

		yield return new WaitForSeconds(timeToWait);

		playerTransform.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
		playerTransform.GetComponent<Rigidbody2D>().AddForce(DegreeToVector2(angle) * force, ForceMode2D.Impulse);
		CharacterControl.instance.SetMovementBlocked(false);
		playerTransform.SetParent(null);
	}

	public static Vector2 RadianToVector2(float radian) {
    	return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
 	}
  
 	public static Vector2 DegreeToVector2(float degree) {
    	return RadianToVector2(degree * Mathf.Deg2Rad);
 	}
}
