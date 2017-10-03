using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;
	
	private AudioSource music;
	
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play ();
		}
		
	}
	
	void OnLevelWasLoaded(int level){
		music.Stop ();
		if(level == 0 ){
			music.clip = startClip;
		}
		else if(level == 1){
			music.clip = gameClip;
		}
		else{
			music.clip = endClip;
		}
		music.loop = true;
		music.Play ();
		
	}
}
