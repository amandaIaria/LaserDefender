using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public static int score = 0;
	public Text text;
	
	void Start(){
		Reset ();
	}

	public static void Reset(){
		score = 0;
	}
	
	public void HitScore(int addToScore){
		score += addToScore;
		text.text = score.ToString();
	}
	
}
