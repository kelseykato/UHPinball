using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	public int TotalScore;
	private float multiplier = 1.0f; 
	public GUIText scoreText;

	void Start() {
		UpdateScore ();
	}

	public void Score(int points) {
		float newScore = points * multiplier;
		TotalScore += (int) newScore;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + TotalScore;
		// print (TotalScore);
	}

	/**
	 * Set the multiplier value with a given float.
	 **/
	public void SetMultiplier(float value) {
		multiplier = value;
	}

	/**
	 * Returns the multiplier value
	 **/
	public float GetMultiplier() {
		return multiplier;
	}

}
