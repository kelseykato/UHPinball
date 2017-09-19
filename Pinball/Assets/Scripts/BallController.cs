using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController: MonoBehaviour {

	private GameController controller;
	private ScoreKeeper ScoringObject;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("GameController").GetComponent<GameController> ();
		ScoringObject = GameObject.Find ("Camera").GetComponent<ScoreKeeper> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Boundary") {
			controller.lives--;
			controller.baseLives--;
			controller.initBall = true;
			Destroy (gameObject);
			if (controller.baseLives < controller.lives) {
				controller.initBall = false;
				controller.baseLives++;
			}
		}

		if (col.gameObject.name == "PaddleR" || col.gameObject.name == "PaddleL") {
			ScoringObject.SetMultiplier (1);
		}
	}
}
