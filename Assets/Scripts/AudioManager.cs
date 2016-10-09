using UnityEngine;
using System.Collections;

public enum Audios {
	Slime,
	Base,
	Win,
	Elastic,
	Died,
	Attraction
}

public class AudioManager : MonoBehaviour {

	public AudioSource[] audiosSources;

	public static AudioManager instance;

	void Awake () {
		instance = this;
	}
	
	public void PlayAudio (Audios audios) {
		audiosSources[(int)audios].Play();
	}
}
