using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	// Use this for initialization
	
	private SoundContainer explosion;
	
	void Start () {
		explosion = GameObject.Find("SoundContainer").GetComponent<SoundContainer>();
		explosion.PlayPlayerDying();
	}
}
