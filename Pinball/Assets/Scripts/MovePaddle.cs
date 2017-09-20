using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour {

	public float forceAmount;
	//public AudioClip hit;
	public AudioSource hit;
	private bool hitReadyR;
	private bool hitReadyL;

	public GameObject paddleL;
	public GameObject paddleR;
	private ScoreKeeper ScoringObject;

	void Start() {
		ScoringObject = GameObject.Find ("Camera").GetComponent<ScoreKeeper> ();
		hitReadyR = true;
		hitReadyL = true;
	}

	void Update() {

		Rigidbody rbl = paddleL.GetComponent<Rigidbody> ();
		Rigidbody rbr = paddleR.GetComponent<Rigidbody> ();

//		rbl.maxAngularVelocity = maxVelocity;
//		rbr.maxAngularVelocity = maxVelocity;

		if (Input.GetKey (KeyCode.Q)) {
			rbl.AddForce (transform.forward * forceAmount, ForceMode.Acceleration);
			rbl.useGravity = true;
			if (hitReadyL) {
				hit.Play ();
				hitReadyL = false;
			}
		} else {
			hitReadyL = true;
			rbl.AddForce (-transform.forward * forceAmount, ForceMode.Acceleration);
			rbl.useGravity = true;
		}


		if (Input.GetKey (KeyCode.E)) {
			rbr.AddForce (transform.forward * forceAmount, ForceMode.Acceleration);
			rbr.useGravity = true;
			if (hitReadyR) {
				hit.Play ();
				hitReadyR = false;
			}
		} else {
			hitReadyR = true;
			rbr.AddForce (-transform.forward * forceAmount, ForceMode.Acceleration);
			rbr.useGravity = true;
		}
	}

	void OnCollisionEnter (Collision collision) {
		ScoringObject.SetMultiplier(1);
//		if (collision.gameObject.name == "EyeBall") {
//			Destroy (bumper);
//			ScoringObject.SetMultiplier(1);
//			print (ScoringObject.TotalScore);	
//		}
	}

}