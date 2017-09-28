using UnityEngine;
using System.Collections;

public class PulseController : MonoBehaviour {
	
	public float damage = 100f;
	
	void Update () {
		PulseMovement();
	}
	
	void PulseMovement(){
		float speed = 20f;
		float speedWithFrames  = speed * Time.deltaTime;
		//transform.rigidbody2D.velocity = new Vector3(0, speedWithFrames, 0);
		transform.position += Vector3.up * speedWithFrames;
	}
	
	public float GetDamage(){
		return damage;
	}
	
	public void Hit(){
		Destroy (gameObject);
	}
	
	
}
