using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {
	public float speed 	= 10.0f;
	public float padding = 1.0f;
	
	private float minX, maxX;
	private bool hasStarted;
	private Rigidbody2D player;
	
	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D>();
		//this is the distance between the player and the camera
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		minX = leftMost.x + padding;
		maxX = rightMost.x - padding;
	}
	
	void Update () {
		PlayerMovement();
	}
	
	void PlayerMovement(){
		float speedWithFrames = speed * Time.deltaTime;		
		if(Input.GetKey(KeyCode.LeftArrow)){
			//Time.deltaTime is the mesaurement of the frames
			transform.position += Vector3.left * speedWithFrames;
		}
		else if(Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speedWithFrames;
		}	
		float newX = Mathf.Clamp(transform.position.x, minX, maxX);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}


	void AutoPlay(){

	}
}
