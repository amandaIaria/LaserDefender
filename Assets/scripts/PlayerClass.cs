using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {
	public float speed;
	public float rateOfFire;
	public float padding = 1.0f;
	public GameObject playerPulse1;
	public GameObject playerPulse2;
	public float health = 250f;
	
	private bool everyOtherPulse = true;
	private float minX, maxX;
	private bool hasStarted;
	private Rigidbody2D player;	
	private SoundContainer playerSounds;
	private LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D>();
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		playerSounds = GameObject.Find("SoundContainer").GetComponent<SoundContainer>();
		//this is the distance between the player and the camera
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		minX = leftMost.x + padding;
		maxX = rightMost.x - padding;
	}
	
	void Update () {
		PlayerMovement();
		PlayerCombat();
	}
	
	void OnTriggerEnter2D(Collider2D col){
		PulseController missile = col.gameObject.GetComponent<PulseController>();
		PlayerDamage(missile);
	}
	
	
	
	//Custom Methods
	
	void PlayerMovement(){
		float speedWithFrames  = speed * Time.deltaTime;
		if(Input.GetKey(KeyCode.LeftArrow)){
			//Time.deltaTime is the mesaurement of the frames
			transform.position += Vector3.left * speedWithFrames;
		}
		else if(Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speedWithFrames;
		}	
		float newX = Mathf.Clamp(transform.position.x, minX, maxX);
		transform.position = new Vector3(newX, transform.position.y, 0);
	}

	void PlayerCombat(){
		float speedWithFrames  = rateOfFire * Time.deltaTime;
		if(Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("PlayerFiring", 0.000001f, speedWithFrames);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("PlayerFiring");
		}
	}
	
	void PlayerFiring(){
		GameObject missile;
		Vector3 offset = new Vector3(0, 1, 0);
		playerSounds.PlayPlayerFiring();
		if(everyOtherPulse){
			everyOtherPulse = false;
			missile = missileInstantiate( transform.position +offset, playerPulse1 ); 
		}
		else{
			everyOtherPulse = true;
			missile = missileInstantiate( transform.position +offset, playerPulse2 ); 
		}
		missile.rigidbody2D.velocity = new Vector2(0, 10);
	}
	
	GameObject missileInstantiate(Vector3 missilePos, GameObject playerPulse){
		return Instantiate(playerPulse, missilePos, Quaternion.identity) as GameObject;
	}
	
	void PlayerDamage(PulseController missile){
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0){
				Destroy (gameObject);
				levelManager.LoadLevel("Win Screen");
			}
		}
	}
	
	
}
