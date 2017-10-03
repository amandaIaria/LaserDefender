using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	void Start () {
		Text myText = GetComponent<Text>();
		myText.text = ScoreController.score.ToString();
		ScoreController.Reset();	
	}
	
}
