using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float health = 150f;
	//What makes this better than using a tag?
	
	void OnTriggerEnter2D(Collider2D col){
		PulseController missile = col.gameObject.GetComponent<PulseController>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0){
				Destroy (gameObject);
			}
		}
	}
}
