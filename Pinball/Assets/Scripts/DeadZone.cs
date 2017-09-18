using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	private GameObject barrier;
	private GameController controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == barrier.name) {
			controller.lives--;
			controller.initBall = true;
			Destroy (this);
		}
	}
}
