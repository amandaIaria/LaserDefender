using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemyPrefab;
	public float width;
	public float height;
	public float speed = 5f;
	
	private float minX, maxX;
	private bool movingRight = true;
	
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		minX = leftMost.x;
		maxX = rightMost.x;
		
		foreach(Transform child in transform){
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity ) as GameObject;
			enemy.transform.parent = child;	
		}
	}
	
	void Update () {
		EnemyMovement();
	}
	
	void EnemyMovement(){
		float speedWithFrames = speed * Time.deltaTime;	
		
		if(movingRight){
			transform.position += Vector3.right * speedWithFrames;
		}
		else{
			transform.position += Vector3.left * speedWithFrames;
		}
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		
		if(leftEdgeOfFormation < minX){
			movingRight = true;
		}
		else if(rightEdgeOfFormation > maxX){
			movingRight = false;
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
}
