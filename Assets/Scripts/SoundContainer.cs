using UnityEngine;
using System.Collections;

public class SoundContainer : MonoBehaviour {
	
	public AudioClip enemyFiring;
	public AudioClip enemyDying;
	public AudioClip playerFiring;
	public AudioClip playerDying;
	
	private float volume = 1f;
	
	public void PlayEnemyFiring(){
		AudioSource.PlayClipAtPoint(enemyFiring, transform.position, volume);
	}
	
	public void PlayPlayerFiring(){
		AudioSource.PlayClipAtPoint(playerFiring,  transform.position, volume-0.5f);
	}
	
	public void PlayEnemyDying(){
		AudioSource.PlayClipAtPoint(enemyDying,  transform.position, volume-0.5f);
	}
	
	public void PlayPlayerDying(){
		AudioSource.PlayClipAtPoint(playerDying,  transform.position, volume);
	}

}
