using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour {

	public int pointsForBumper;
	private ScoreKeeper ScoringObject;
	public GameObject bumper;

//	void Awake(){
//		ScoringObject = gameObject.Find("Main_Camera");
//	}

	// Use this for initialization
	void Start () {
		ScoringObject = GameObject.Find ("Camera").GetComponent<ScoreKeeper> ();
	}
	
	// Update is called once per frame
	void Update () {

//		if (ScoringObject.TotalScore > 50) {
//			Destroy (bumper);
//		}
	}

	void OnCollisionEnter (Collision collision) {

		if (collision.gameObject.name == "EyeBall") {
			//Destroy (bumper);
			ScoringObject.Score (pointsForBumper);
			//print (ScoringObject.TotalScore);	
		}
	}
}
