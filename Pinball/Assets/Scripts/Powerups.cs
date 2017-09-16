using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {


	public GameObject token;
	private bool left = true;
	private bool right = false;
	public float moveSpeed;
	private float rotateSpeed;
	private PowerupSpawner spawner;

	// Use this for initialization
	void Start () {
		spawner = GameObject.Find ("Powerups").GetComponent<PowerupSpawner> ();
		rotateSpeed = 50;
	}
	
	// Update is called once per frame
	void Update () {
		MoveHorizontal ();
		Rotate ();
	}

	void OnCollisionEnter(Collision col) {
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


