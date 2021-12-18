using UnityEngine;
using System.Collections;

public class AudioSources : MonoBehaviour {

	
	public static AudioSources instance;
    [HideInInspector]
    public  AudioSource [] audioSources;
	public AudioClip bubbleSFX;
	void Awake ()
	{
		if (instance == null) {
			instance = this;
			audioSources = GetComponents<AudioSource>();
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	public void PlayBubbleSFX(){
		if (bubbleSFX != null && audioSources[1] != null) {
			CommonUtil.PlayOneShotClipAt (bubbleSFX, Vector3.zero, audioSources[1].volume);
		}

	}
}
