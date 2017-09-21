using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	public int TotalScore;
	private float multiplier = 1.0f; 
	public GUIText scoreText;
	public GUIText multiplierText;
	private GameController controller;

	void Start() {
		controller = GameObject.Find ("GameController").GetComponent<GameController> ();
	}

	void Update() {
		if (controller.gameState == 0) {
			TotalScore = 0;
			multiplier = 1;
		}
		if (controller.gameState == 1) {
			UpdateScore ();
			UpdateMultiplier ();
		}
	}

	public void Score(int points) {
		float newScore = points * multiplier;
		TotalScore += (int) newScore;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "score " + TotalScore;
		// print (TotalScore);
	}

	void UpdateMultiplier() {
		multiplierText.text = "multiplier " + multiplier;
		// print (TotalScore);
	}
	/**
	 * Set the multiplier value with a given float.
	 **/
	public void SetMultiplier(float value) {
		multiplier = value;
		UpdateMultiplier ();
	}

	/**
	 * Returns the multiplier value
	 **/
	public float GetMultiplier() {
		return multiplier;
	}

}
