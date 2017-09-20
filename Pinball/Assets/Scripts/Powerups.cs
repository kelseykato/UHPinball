using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {


	public GameObject token;
	public GameObject ball;
	private bool left = true;
	private bool right = false;
	private float moveSpeed;
	private float rotateSpeed;
	private int index;

	private PowerupSpawner spawner;
	private ScoreKeeper ScoringObject;
	private GameController controller;


	// Use this for initialization
	void Start () {
		spawner = GameObject.Find ("Powerups").GetComponent<PowerupSpawner> ();
		ScoringObject = GameObject.Find ("Camera").GetComponent<ScoreKeeper> ();
		controller = GameObject.Find ("GameController").GetComponent<GameController> ();
		rotateSpeed = 50;
		moveSpeed = 4;
	}
	
	// Update is called once per frame
	void Update () {
		MoveHorizontal ();
		Rotate ();

		if (controller.gameState == 0) {
			Destroy (token);
		}
	}

	void OnCollisionEnter(Collision col) {
		
		index = spawner.index;
		// print (index);
		float oldMult = ScoringObject.GetMultiplier ();
		ScoringObject.Score (50);
		Vector3 ballSpawn = new Vector3(-12.0f, 12.0f, 5.0f);
		Quaternion ballRotation = Quaternion.identity;

		switch (index) {
		case 0:
			ScoringObject.SetMultiplier (oldMult += 5.0f);
			index = -1;
			break;
		case 1:
			Instantiate (ball, ballSpawn, ballRotation);
			controller.AddLife ();
			index = -1;
			break;
		case 2: 
			ScoringObject.Score (100);
			index = -1;
			break;
		default:
			break;
		}

		Destroy (token);
		spawner.activePowerup = false;
	}


	void MoveHorizontal (){
		
		Transform body = token.GetComponent<Transform> ();
		float move = moveSpeed * Time.deltaTime;

		if (left) {
			body.Translate (-move, 0, 0, Space.World); 
		}

		else if (right) {
			body.Translate (move, 0, 0, Space.World); 
		}

		if (body.position.x <= -spawner.spawnValues.x) {
			right = true;
			left = false;
		}

		if (body.position.x >= spawner.spawnValues.x) {
			left = true;
			right = false;
		}
	}

	void Rotate () {
		Transform body = token.GetComponent<Transform> ();
		float move = rotateSpeed * Time.deltaTime;

		body.Rotate (0, move, 0, Space.World);
	}


}


