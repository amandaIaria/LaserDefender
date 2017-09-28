using UnityEngine;
using System.Collections;

public class PulseController : MonoBehaviour {
	void Update () {
		float speed = 10f;
		float speedWithFrames  = speed * Time.deltaTime;
		transform.position += Vector3.up * speedWithFrames;
	}
}
