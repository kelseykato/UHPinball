using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {


	public GameObject token;
	public GameObject ball; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == ball.name) {
			Destroy (token);
		}
	}

}


