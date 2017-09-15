using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate_Horizontal : MonoBehaviour {

	private bool left = true;
	private bool right = false;
	public GameObject block;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Transform body = block.GetComponent<Transform> ();
		float move = speed * Time.deltaTime;

		if (left) {
			body.Translate (-move, 0, 0); 
		}

		else if (right) {
			body.Translate (move, 0, 0); 
		}

		if (body.position.x <= -6) {
			right = true;
			left = false;
		}

		if (body.position.x >= 6) {
			left = true;
			right = false;
		}


	}
}
