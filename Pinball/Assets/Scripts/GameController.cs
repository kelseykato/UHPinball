using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	internal int gameState;
	internal int lives;
	internal int baseLives;
	public GameObject ball;
	public GameObject camera;
	private Transform cameraPosition;

	public GUIText gameOverText;
	public GUIText startText;
	public GUIText livesText;
	public GUIText restartText;
	public GUIText launchBallText;
	public GUIText flipperText;

	private Vector3 ballSpawn;
	private Vector3 cameraPosGame;
	private Vector3 cameraPosMenu;
	private Vector3 cameraRotGame;
	private Vector3 cameraRotMenu;

	private Quaternion ballRotation;
	internal bool initBall;
	private bool flipperTextActive;

	private PowerupSpawner PowerSpawner;
	private ScoreKeeper ScoringObject;

	// Use this for initialization
	void Start () {
		gameState = 0;

		ballSpawn = new Vector3(4.5f, 12.7f, 8.0f);
		cameraPosGame = new Vector3(0f, 18.6f, -21.5f);
		cameraPosMenu = new Vector3(40.0f, 20.0f, -25.0f);
		cameraRotGame = new Vector3 (15.0f, 0, 0);
		cameraRotMenu = new Vector3(20.0f, -45.0f, 0f);

		ballRotation = Quaternion.identity;
		initBall = true;
		flipperTextActive = true;
		PowerSpawner = GameObject.Find ("Powerups").GetComponent<PowerupSpawner> ();
		ScoringObject = GameObject.Find ("Camera").GetComponent<ScoreKeeper> ();
		cameraPosition = camera.GetComponent<Transform> ();
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
				ScoringObject.TotalScore = 0;
				flipperTextActive = true;
			}
			break;

		case 0:
			cameraPosition.position = cameraPosMenu;
			cameraPosition.rotation = Quaternion.Euler(cameraRotMenu.x, cameraRotMenu.y, cameraRotMenu.z);
			EraseAllText ();
			startText.text = "Press SPACE to Start";
			if (Input.GetKey (KeyCode.Space)) {
				gameState = 1;
				lives = 3;
				baseLives = lives;
			}
			break;

		case 1:
			cameraPosition.position = cameraPosGame;
			cameraPosition.rotation = Quaternion.Euler (cameraRotGame.x, cameraRotGame.y, cameraRotGame.z);
			EraseAllText ();
			UpdateLifeCount ();
			if (initBall && Input.GetKey (KeyCode.F)) {
				launchBallText.text = null;
				Instantiate (ball, ballSpawn, ballRotation);
				initBall = false;
			}
			if (initBall) {
				launchBallText.text = "Press F to launch ball";
			}
			if (flipperTextActive) {
				flipperText.text = "Q and E to use flippers";
				if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.E)) {
					flipperTextActive = false;
				}
			}
			if (lives <= 0)
				gameState = -1;
			break;

		default:
			break;
		}
	}

	public void AddLife() {
		if (lives <= 3) {
			baseLives = lives;
		}
		lives++;
		UpdateLifeCount ();
	}

	void UpdateLifeCount() {
		livesText.text = "Balls: " + lives;
	}

	void EraseAllText() {
		startText.text = null;
		gameOverText.text = null;
		restartText.text = null;
		livesText.text = null;
		launchBallText.text = null;
		flipperText.text = null;
	}
}
