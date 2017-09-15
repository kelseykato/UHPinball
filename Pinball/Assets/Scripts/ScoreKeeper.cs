using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	public int TotalScore;
	public GUIText scoreText;

	void Start() {
		UpdateScore ();
	}

	public void Score(int points) {
		TotalScore += points;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + TotalScore;
		if (scoreText.text == "Score: " + TotalScore) {
			print (TotalScore);
		}
	}

}
