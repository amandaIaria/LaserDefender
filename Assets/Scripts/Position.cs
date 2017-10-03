using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	//This is for development. IN the editor it will draw these Gizmos
	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
