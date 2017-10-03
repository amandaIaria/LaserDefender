using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float health = 150f;
	public float fireRate;
	public GameObject enemyPulse1;
	public GameObject enemyPulse2;
	public float shootsPerSecond = 0.5f;
	public int enemyValue;
	
	private ScoreController scoreKeeper;
	private bool everyOtherPulse = false;
	private SoundContainer enemySounds;
	
	void Start(){
		scoreKeeper = GameObject.Find ("ScoreValue").GetComponent<ScoreController>();
		enemySounds = GameObject.Find("SoundContainer").GetComponent<SoundContainer>();
	}
	
	void Update(){
		float probability = Time.deltaTime * shootsPerSecond;
		if(Random.value < probability){
			EnemyFiring();
		}
	}
	
	void OnTriggerEnter2D(Collider2D col){
		PulseController missile = col.gameObject.GetComponent<PulseController>();
		EnemyDamage(missile);
	}
	
	
	//Custom Methods
	void EnemyFiring(){
		//float speedWithFrames  = fireRate * Time.deltaTime;
		GameObject missile;
		Vector3 missilePos = transform.position + new Vector3(0,-1 ,0);
		enemySounds.PlayEnemyFiring();
		if(everyOtherPulse){
			everyOtherPulse = false;
			missile = missileInstantiate(missilePos, enemyPulse1); 
		}
		else{
			everyOtherPulse = true;
			missile = missileInstantiate(missilePos, enemyPulse2 ); 
		}
		missile.rigidbody2D.velocity = new Vector2(0, -10);
	}
	
	GameObject missileInstantiate(Vector3 missilePos, GameObject enemyPulse){
		return Instantiate(enemyPulse, missilePos, Quaternion.identity) as GameObject;
	}
	
	void EnemyDamage(PulseController missile){
		print (enemyValue);
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0){
				Destroy (gameObject);
				enemySounds.PlayEnemyDying();
				scoreKeeper.HitScore (enemyValue);
			}
		}
	}
}
