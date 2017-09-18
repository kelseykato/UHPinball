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
	private PowerupSpawner spawner;
	private ScoreKeeper ScoringObject;
	private int index;

	// Use this for initialization
	void Start () {
		spawner = GameObject.Find ("Powerups").GetComponent<PowerupSpawner> ();
		ScoringObject = GameObject.Find ("Camera").GetComponent<ScoreKeeper> ();
		rotateSpeed = 50;
		moveSpeed = 4;
	}
	
	// Update is called once per frame
	void Update () {
		MoveHorizontal ();
		Rotate ();
	}

	void OnCollisionEnter(Collision col) {
		
		index = spawner.index;
		print (index);
		float oldMult = ScoringObject.GetMultiplier ();
		ScoringObject.Score (50);
		Vector3 ballSpawn = new Vector3(2.5f, 2.0f, 3.0f);
		Quaternion ballRotation = Quaternion.identity;

		switch (index) {
		case 0:
			ScoringObject.SetMultiplier (oldMult += 5);
			index = -1;
			break;
		case 1:
			Instantiate (ball, ballSpawn, ballRotation);
			index = -1;
			break;
		default:
			break;
		}

		Destroy (token);
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


