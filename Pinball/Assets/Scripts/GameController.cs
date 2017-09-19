using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	internal int gameState;
	internal int lives;
	internal int baseLives;
	public GameObject ball;

	public GUIText gameOverText;
	public GUIText startText;
	public GUIText livesText;
	public GUIText restartText;
	public GUIText launchBallText;

	private Vector3 ballSpawn;
	private Quaternion ballRotation;
	internal bool initBall;

	private PowerupSpawner PowerSpawner;

	// Use this for initialization
	void Start () {
		gameState = 0;
		ballSpawn = new Vector3(2.5f, 2.0f, 3.0f);
		ballRotation = Quaternion.identity;
		initBall = true;
		PowerSpawner = GameObject.Find ("Powerups").GetComponent<PowerupSpawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		switch (gameState) {
		case -1:
			gameOverText.text = "YOU SUCK";
			restartText.text = "Press R to return to start";
			launchBallText.text = null;
			if(Input.GetKey(KeyCode.R)) {
				gameState = 0;
				PowerSpawner.ResetLimit ();
			}
			break;

		case 0:
			gameOverText.text = null;
			restartText.text = null;
			livesText.text = null;
			launchBallText.text = null;
			startText.text = "Press SPACE to Start";
			if (Input.GetKey (KeyCode.Space)) {
				gameState = 1;
				lives = 3;
				baseLives = lives;
			}
			break;

		case 1:
			startText.text = null;
			gameOverText.text = null;
			UpdateLifeCount ();
			if (initBall && Input.GetKey (KeyCode.F)) {
				launchBallText.text = null;
				Instantiate (ball, ballSpawn, ballRotation);
				initBall = false;
			}
			if (initBall) {
				launchBallText.text = "Press F to launch ball";
			}
			if (lives <= 0)
				gameState = -1;
			break;

		default:
			break;
		}
	}

	public void AddLife() {
		baseLives = lives;
		lives++;
		UpdateLifeCount ();
	}

	void UpdateLifeCount() {
		livesText.text = "Balls: " + lives;
	}


}
