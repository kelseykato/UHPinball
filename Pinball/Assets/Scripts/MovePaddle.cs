using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour {

	public float forceAmount;
	public float maxVelocity;
	public GameObject paddleL;
	public GameObject paddleR;

	void Start() {
	
	}

	void Update() {

		Rigidbody rbl = paddleL.GetComponent<Rigidbody> ();
		Rigidbody rbr = paddleR.GetComponent<Rigidbody> ();

		rbl.maxAngularVelocity = maxVelocity;
		rbr.maxAngularVelocity = maxVelocity;

		if (Input.GetKey (KeyCode.Q)) {
			rbl.AddForce (transform.forward * forceAmount, ForceMode.Acceleration);
			rbl.useGravity = true;
		} else {
			rbl.AddForce (-transform.forward * forceAmount, ForceMode.Acceleration);
			rbl.useGravity = true;
		}


		if (Input.GetKey (KeyCode.E)) {
			rbr.AddForce (transform.forward * forceAmount, ForceMode.Acceleration);
			rbr.useGravity = true;
		} else {
			rbr.AddForce (-transform.forward * forceAmount, ForceMode.Acceleration);
			rbr.useGravity = true;
		}
	}

}