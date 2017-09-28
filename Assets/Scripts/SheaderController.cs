using UnityEngine;
using System.Collections;

public class SheaderController : MonoBehaviour {
	
	//TODO: I created this to go along with the course. I'm not sure what would be more preformance working. This or what I did.
	// What I did can be found on the bottom

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col){
		Destroy(col.gameObject);
	}
	/* In the pulse object I created it's own movement. I thought it would be better to keep the movement on the object.
		So in the PulseController:
		
		private float maxY;
	
		void Start(){
			float distance = transform.position.z - Camera.main.transform.position.z;
			Vector3 upMost = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance));
			maxY = upMost.y;
		}
		
		void Update () {
			float speed = 10f;
			float speedWithFrames  = speed * Time.deltaTime;
			
			transform.position += Vector3.up * speedWithFrames;
			
			if( maxY < transform.position.y ){
				Destroy (gameObject);
			}
		}
	*/
}
