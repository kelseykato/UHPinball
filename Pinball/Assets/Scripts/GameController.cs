using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	internal int gameState;
	internal int lives;
	public GameObject ball;
	public GUIText gameOverText;
	public GUIText startText;
	private Vector3 ballSpawn;
	private Quaternion ballRotation;
	internal bool initBall;


	// Use this for initialization
	void Start () {
		gameState = 0;
		ballSpawn = new Vector3(2.5f, 2.0f, 3.0f);
		ballRotation = Quaternion.identity;
		initBall = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		switch (gameState) {
		case -1:
			gameOverText.text = "YOU SUCK";
			break;
		case 0:
			startText.text = "Press SPACE to Start";
			if (Input.GetKey (KeyCode.Space)) {
				gameState = 1;
				lives = 3;
			}
			break;
		case 1:
			startText.text = null;
			if (initBall && Input.GetKey(KeyCode.F)) {
				Instantiate (ball, ballSpawn, ballRotation);
				initBall = false;
			}
			TrackBall ();
			if (lives <= 0)
				gameState = -1;
			break;
		default:
			break;
		}
	}

	void TrackBall() {
		Transform pos = ball.GetComponent<Transform> ();

		if (pos.position.y <= -15) {
			lives--;
			initBall = true;
			Destroy (ball);
		}
	}
}
